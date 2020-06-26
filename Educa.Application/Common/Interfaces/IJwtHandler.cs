using Educa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Infrastructure.Jwt
{
    public interface IJwtHandler
    {
        string Generate(ApplicationUser user,List<string> roles);
    }
}
