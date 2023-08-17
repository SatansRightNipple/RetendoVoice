using System.Net;

namespace RetendoVoice.Models
{
    public class OpenAiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public OpenAiException(string message, HttpStatusCode httpStatusCode) : base(message) 
        {
            StatusCode = httpStatusCode;
        }
    }
}
