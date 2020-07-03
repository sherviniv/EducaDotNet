using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using Educa.Domain.Statics;
using Educa.WebUI.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Educa.WebUI.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class AccountController : ApiController
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("{id}")]
        public async Task<DataResult<UserDto>> GetUser(string userId)
        {
            return await _identityService.GetUserAsync(userId);
        }

        [HttpPost]
        public async Task<ServerResult> CreateUser(UserDto dtoModel)
        {
            return await _identityService.CreateUserAsync(dtoModel);
        }

        [HttpPut("[action]")]
        public async Task<ServerResult> UpdateUser(UserDto dtoModel)
        {
            return await _identityService.UpdateUserAsync(dtoModel);
        }

        [HttpDelete("{id}")]
        public async Task<ServerResult> DeleteUser(string userId)
        {
            return await _identityService.DeleteUserAsync(userId);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<DataResult<string>> Login(LoginDto dtoModel)
        {
            return await _identityService.LoginUserAsync(dtoModel);
        }
    }
}
