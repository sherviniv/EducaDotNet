using AutoMapper;
using Educa.Application.Common.Models.Dtos;
using Educa.Application.Common.Models.ViewModels;
using Educa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Mapping
{
    public class MapperProfle : Profile
    {
        public MapperProfle()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<UserVM, ApplicationUser>().ReverseMap();
        }
    }
}
