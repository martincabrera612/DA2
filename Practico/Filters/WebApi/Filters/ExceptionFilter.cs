using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            int statusCode = 500;
            ResponseDto response = new ResponseDto
            {
                ExecutionSuccessful = false,
                Message = "Internal server error"
            };
            if (context.Exception is Exception)
            {
                statusCode = 400;
                response.Message = "An error occurred";
            }
            if (context.Exception is ArgumentException)
            {
                statusCode = 400;
                response.Message = "Invalid data";
            }
            if (context.Exception is ArgumentNullException)
            {
                statusCode = 400;
                response.Message = "Argument cant be null";
            }
            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };
        }
    }
}
