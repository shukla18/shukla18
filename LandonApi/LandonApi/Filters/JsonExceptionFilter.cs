using LandonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LandonApi.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public JsonExceptionFilter(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiError()
            {
                Message = context.Exception.Message,
            };

            if (_environment.IsDevelopment())
            {
                error.Details = context.Exception.StackTrace;
            }
            else
            {
                error.Details = "An error occured";
            }

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}
