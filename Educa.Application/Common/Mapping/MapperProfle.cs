using AutoMapper;
using Educa.Application.Common.Models.Dtos;
using Educa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Mapping
{
    public class MapperProfle : Profile
    {
        public void MapProfiles() 
        {
            CreateMap<UserDto, ApplicationUser>().ReverseMap();
        }
    }
}
