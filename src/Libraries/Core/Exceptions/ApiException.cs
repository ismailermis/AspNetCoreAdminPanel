using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Core.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
        public int StatusCode { get; set; }
        public string MessageText { get; set; }
        public bool Success => StatusCode < 400;
        public ApiException(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            MessageText = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Errors lead to anger.  Anger leads to hate.  Hate leads to career change",
                _ => null
            };
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
