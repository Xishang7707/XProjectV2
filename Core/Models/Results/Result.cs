using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Results
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string Msg { get; private set; }

        public Result(bool isSuccess, string msg)
        {
            IsSuccess = isSuccess;
            Msg = msg;
        }
    }
}
