using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels
{
    public class JsonResult<T> : ServerResult
    {
        public T Data { get; set; }

        public JsonResult()
        {
        }

        public JsonResult(T data, bool succeeded = true)
        {
            Data = data;
            Succeeded = succeeded;
        }
    }
}
