using Educa.Application.Common.Exceptions;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using Educa.Domain.Entities;
using Educa.Infrastructure.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Educa.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtHandler _jwtHandler;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            IJwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<ServerResult> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

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

        public async Task<JsonResult<string>> LoginUserAsync(LoginDto model)
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

            return new JsonResult<string>(_jwtHandler.Generate(user));
        }

    }
}
