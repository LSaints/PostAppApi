using PostAppApi.Domain.Commons;
using PostAppApi.Exceptions.Messages;
using PostAppApi.Exceptions.PostExceptions;
using PostAppApi.Exceptions.UserExceptions;
using System.Net;
using System.Text.Json;

namespace PostAppApi.Api.Middlewares.ExceptionsMiddleware
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
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
                case ApplicationException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.BadRequest;
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    exceptionModel.ReponseMessage = MessagesExceptions.BAD_REQUEST_EXCEPTION;
                    break;
                case FileNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = MessagesExceptions.NOT_FOUND_EXCEPTION;
                    break;
                case PostNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = PostMessagesExceptions.NOT_FOUND_EXCEPTION;
                    break;
                case UserPostNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = PostMessagesExceptions.USER_NOT_FOUND_EXCEPTION;
                    break;
                case UserNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = UserMessagesExceptions.NOT_FOUND_EXCEPTION;
                    break;
                case EmailNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = UserMessagesExceptions.EMAIL_NOT_FOUND_EXCEPTION;
                    break;
                case UsernameNotFoundException ex:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.NotFound;
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    exceptionModel.ReponseMessage = UserMessagesExceptions.USERNAME_NOT_FOUND_EXCEPTION;
                    break;
                default:
                    exceptionModel.ResponseStatus = (int)HttpStatusCode.InternalServerError;
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    exceptionModel.ReponseMessage = MessagesExceptions.INTERNAL_SERVER_ERROR;
                    break;
            }
            var exceptionResult = JsonSerializer.Serialize(exceptionModel);
            await context.Response.WriteAsync(exceptionResult);
        }
    }
}
