using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.BaseModels.ClientSide.Grid;
using Educa.Application.Common.Models.Dtos;
using Educa.Application.Common.Models.ViewModels;
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
        public async Task<DataResult<UserDto>> GetUser(string id)
        {
            return await _identityService.GetUserAsync(id);
        }

        [HttpPost("[action]")]
        public async Task<GridData<UserVM>> GetAll(GridQuery query)
        {
            return await _identityService.GetUsersGridAsync(query);
        }

        [HttpPost]
        public async Task<ServerResult> CreateUser(UserDto dtoModel)
        {
            return await _identityService.CreateUserAsync(dtoModel);
        }

        [HttpPut]
        public async Task<ServerResult> UpdateUser(UserDto dtoModel)
        {
            return await _identityService.UpdateUserAsync(dtoModel);
        }

        [HttpDelete("{id}")]
        public async Task<ServerResult> DeleteUser(string id)
        {
            return await _identityService.DeleteUserAsync(id);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<DataResult<string>> Login(LoginDto dtoModel)
        {
            return await _identityService.LoginUserAsync(dtoModel);
        }
    }
}
