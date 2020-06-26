using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels
{
    public class DataResult<T> : ServerResult
    {
        public T Data { get; set; }

        public DataResult()
        {
        }

        public DataResult(T data, bool succeeded = true)
        {
            Data = data;
            Succeeded = succeeded;
        }
    }
}
