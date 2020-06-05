using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using Educa.WebUI.Base;
using Microsoft.AspNetCore.Mvc;

namespace Educa.WebUI.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<JsonResult<string>> Login(LoginDto dtoModel)
        {
            return await _identityService.LoginUserAsync(dtoModel);
        }

        //[HttpPost]
        //public async Task<JsonResult<string>> CreateUser(LoginDto dtoModel)
        //{
        //    return await _identityService.CreateUserAsync(dtoModel);
        //}

    }
}
