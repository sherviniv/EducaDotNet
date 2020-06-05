using Educa.Infrastructure.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels
{
    public class AppSettings
    {
        public JwtConfig Jwt { get; set; }
    }
}
