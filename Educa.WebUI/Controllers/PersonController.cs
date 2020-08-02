using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using Educa.Application.Interfaces;
using Educa.Domain.Statics;
using Educa.WebUI.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educa.WebUI.Controllers
{
    [Authorize(Roles = RoleNames.Admin)]
    public class PersonController : ApiController
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<ServerResult> Create(PersonDto dtoModel)
        {
            return await _personService.CreateAsync(dtoModel);
        }
    }
}
