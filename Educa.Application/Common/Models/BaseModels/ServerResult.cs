using System;
using System.Collections.Generic;
using System.Text;

namespace Educa.Application.Common.Models.BaseModels
{
    public class ServerResult
    {
        public ServerResult()
        {
        }

        public ServerResult(bool succeeded, string message = "")
        {
            (this.Succeeded,this.Message) = (succeeded,message);
        }

        public static ServerResult Success()
        {
            return new ServerResult(true);
        }


        public static ServerResult Exception(string message,string status = "exception",string[] errors = default)
        {
            return new ServerResult()
            {
                Succeeded = false,
                Message = message,
                IsException = true,
                Status = status,
                Errors = errors
            };
        }

        public bool Succeeded { get; set; }
        protected bool IsException { get; set; }
        protected string Status { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
    }
}
