using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamApi.Domain.Models.CustomException
{
    public class AppException : Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

        public AppException(HttpStatusCode httpStatusCode, string message)
        {
            ErrorMessage = message;
            StatusCode = (int)httpStatusCode;
        }
    }
}
