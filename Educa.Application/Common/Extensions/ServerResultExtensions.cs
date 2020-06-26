using Educa.Application.Common.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Extensions
{
    public static class ServerResultExtensions
    {
        public static DataResult<T> ToJsonResult<T>(this T data, bool succeeded = true)
        {
            return new DataResult<T> { Data = data, Succeeded = succeeded };
        }
    }
}
