using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ChallengeFIAPLibrary.Application.Abstraction
{
    public class Result<T>(bool isSuccess, string message, bool isFound = true, T data = default) : IRequest
    {
        public bool IsSuccess { get; } = isSuccess;
        public bool IsFound { get; } = isFound;
        public string Message { get; } = message;
        public T Data { get; } = data;

        public static Result<T> Success(T data, string message = "Success Operation")
        {
            return new Result<T>(true, message, data: data);
        }

        public static Result<T> Failure(string message = "Failed Operation")
        {
            return new Result<T>(false, message);
        }

        public static Result<T> NotFound(string message = "Item Not Found")
        {
            return new Result<T>(false, message, false);
        }

    }
}
