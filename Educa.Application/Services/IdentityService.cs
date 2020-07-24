using AutoMapper;
using AutoMapper.QueryableExtensions;
using Educa.Application.Common.Exceptions;
using Educa.Application.Common.Extensions;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.BaseModels.ClientSide.Grid;
using Educa.Application.Common.Models.Dtos;
using Educa.Application.Common.Models.ViewModels;
using Educa.Domain.Entities;
using Educa.Infrastructure.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educa.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IJwtHandler jwtHandler,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<DataResult<List<UserVM>>> GetUsersAsync() 
        {
            var users = await _userManager.Users
                .ProjectTo<UserVM>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new DataResult<List<UserVM>>(users);
        }

        public async Task<GridData<UserVM>> GetUsersGridAsync(GridQuery query)
        {
            var users = _userManager.Users
                .ProjectTo<UserVM>(_mapper.ConfigurationProvider);

            throw new NotImplementedException();
        }

        public async Task<DataResult<UserDto>> GetUserAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            if (user == null)
                throw new EducaException("userId_not_found", "User was not found.");

            return _mapper.Map(user,new UserDto()).ToJsonResult();
        }

        public async Task<ServerResult> CreateUserAsync(UserDto model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result.Succeeded ? ServerResult.Success() : new ServerResult()
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description).ToArray()
            };
        }

        public async Task<ServerResult> DeleteUserAsync(string userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return ServerResult.Success();
        }

        public async Task<ServerResult> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded ? ServerResult.Success() : new ServerResult()
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description).ToArray()
            }; 
        }

        public async Task<ServerResult> UpdateUserAsync(UserDto model)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == model.UserName);

            if (user == null)
                throw new EducaException("userName_not_found"
                    , $"UserName: '{model.UserName}' was not found.");

            _mapper.Map(model, user);

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded ? ServerResult.Success() : new ServerResult()
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description).ToArray()
            };
        }

        public async Task<DataResult<string>> LoginUserAsync(LoginDto model)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == model.UserName);

            if (user == null)
                throw new EducaException("invalid_credentials",
                        "User cannot be find.");

            var result = await _signInManager.CheckPasswordSignInAsync(user
                  , model.Password, true);

            if (!result.Succeeded)
                throw new EducaException("invalid_credentials",
                    "invalid credentials.");

            var roles = await _userManager.GetRolesAsync(user);

            return new DataResult<string>(_jwtHandler.Generate(user,roles.ToList()));
        }
    }
}
