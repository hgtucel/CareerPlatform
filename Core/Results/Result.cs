﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message)
        {
            Message = message;
            Success = success;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
