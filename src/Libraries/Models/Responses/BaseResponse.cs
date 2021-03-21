using System.Collections.Generic;

namespace Models.Responses
{
    public class BaseResponse<T>
    {
        public bool Success => StatusCode < 400;
        public int StatusCode { get; set; }
        public BaseResponse()
        {
        }
        public BaseResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }
        public BaseResponse(T data, string message = null)
        {
            Message = message;
            Data = data;
        }
        public BaseResponse(string message)
        {
            Message = message;
            Succeeded = false;
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
        public bool Succeeded;
        public string Message { get; set; }
        public List<string> Errors;
        public T Data { get; set; }
    }
}
