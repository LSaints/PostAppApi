using PostAppApi.Domain.Commons;
using PostAppApi.Exceptions.Messages;
using PostAppApi.Exceptions.PostExceptions;
using System.Net;
using System.Text.Json;

namespace PostAppApi.Api.Middlewares.ExceptionsMiddleware
{
    public class PostExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public PostExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            ExceptionResponse exceptionModel = new ExceptionResponse();

            switch (exception)
            {
                case PostNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = PostMessagesExceptions.NOT_FOUND_EXCEPTION;
                    break;
                case UserNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = PostMessagesExceptions.USER_NOT_FOUND_EXCEPTION;
                    break;


            }
            var exceptionResult = JsonSerializer.Serialize(exceptionModel);
            await context.Response.WriteAsync(exceptionResult);
        }
    }
}
