﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Responses
{
    public class GenericResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }

        public GenericResponse(bool success, string message, int statusCode, T data = default)
        {
            Success = success;
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }
    }

}
