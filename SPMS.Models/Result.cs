using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPMS.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public bool IsError => !IsSuccess;
        public T Data { get; set; }
        public string Message { get; set; }

        public static Result<T> Success(T data, string message = "Operation Successful.")
        {
            return new Result<T>
            {
                Data = data,
                Message = message,
                IsSuccess = true
            };
        }

        public static Result<T> Error(string message = "Internal server error.")
        {
            return new Result<T>
            {
                Message = message,
                IsSuccess = false
            };
        }

        public static Result<T> Error(Exception ex)
        {
            return new Result<T>
            {
                Message = ex.ToString(),
                IsSuccess = false
            };
        }
    }
}