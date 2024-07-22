
using Newtonsoft.Json;

namespace School.Middleware
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public ErrorResponse(string errorCode, string message, IEnumerable<string> errors)
        {
            ErrorCode = errorCode;
            Message = message;
            Errors = errors;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
