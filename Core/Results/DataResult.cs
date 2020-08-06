using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message): base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success): base(success)
        {
            Data = data;
        }
        //Sadece message varsa başarısız demektir. False yaptık.
        public DataResult(string message):base(false,message)
        {

        }
        public T Data { get; }
    }
}
