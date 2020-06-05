using Educa.Application.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Extensions
{
    public static class ServerResultExtensions
    {
        public static JsonResult<T> ToJsonResult<T>(this T data, bool succeeded = true)
        {
            return new JsonResult<T> { Data = data, Succeeded = succeeded };
        }
    }
}
