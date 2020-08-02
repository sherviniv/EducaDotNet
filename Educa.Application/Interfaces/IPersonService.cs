using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Application.Interfaces
{
    public interface IPersonService
    {
        Task<ServerResult> CreateAsync(PersonDto model);
    }
}
