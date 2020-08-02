using AutoMapper;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Common.Models.Dtos;
using Educa.Application.Interfaces;
using Educa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Educa.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IEducaDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(IEducaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServerResult> CreateAsync(PersonDto model)
        {
            var newModel = _mapper.Map<Person>(model);
            _context.People.Add(newModel);
            await _context.SaveChangesAsync();
            return ServerResult.Success();
        }
    }
}
