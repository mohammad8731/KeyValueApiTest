﻿using System.Net;
using System.Text.Json;
using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.Identity.Request;
using AzarDataNetTestAPI.Modules.Common.Application.Contracts.Dto.ServiceResult.Response;
using AzarDataNetTestAPI.Modules.Common.Application.Services.Logs;
using AzarDataNetTestAPI.Modules.Common.Domain.Exceptions.Common;
using Microsoft.AspNetCore.Http.HttpResults;
using static AzarDataNetTestAPI.Modules.Common.Infrastructure.Data.Configs.Constants.IConstants;
using ILogger = NLog.ILogger;


namespace AzarDataNetTestAPI.Modules.Common.Application.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DBOperationFailedException ex)
            {
                await CheckDatabaseException(httpContext, ex, ex.MainException,ex.StatusCode);
            }
            catch (ThirdPartyConnectionException ex)
            {
                await CheckOtherException(httpContext, ex);
            }
            catch (FileIOException ex)
            {
                await CheckFileIOException(httpContext, ex, ex.MainException,ex.StatusCode);
            }
            catch (CommonException ex)
            {
                await CheckCommonException(httpContext, ex,ex.StatusCode);
            }
            catch (SmsEmailException ex)
            {
                await CheckSmsEmailException(httpContext, ex);
            }
            catch (Exception ex)
            {
                await CheckOtherException(httpContext, ex);
            }
        }

        private async Task CheckSmsEmailException(HttpContext httpContext, SmsEmailException ex)
        {
            ILogger logger = MyNLog.GetLogger(LoggerType.SendingMessageLogger);
            logger.Error(AddTraceToMessage(ex, null));
            await HandleExceptionAsync(httpContext, ex.Message,ex.StatusCode);
        }

        private async Task CheckFileIOException(HttpContext context, Exception ex, Exception mainException,short statusCode)
        {
            ILogger logger = MyNLog.GetLogger(LoggerType.FileIOExpLogger);
            if (mainException.GetType() == typeof(ArgumentNullException)
                || mainException.GetType() == typeof(ArgumentException)
                || mainException.GetType() == typeof(NotSupportedException)
                || mainException.GetType() == typeof(System.Security.SecurityException)
                || mainException.GetType() == typeof(FileNotFoundException)
                || mainException.GetType() == typeof(UnauthorizedAccessException)
                || mainException.GetType() == typeof(IOException)
                || mainException.GetType() == typeof(DirectoryNotFoundException)
                || mainException.GetType() == typeof(PathTooLongException)
                || mainException.GetType() == typeof(ArgumentOutOfRangeException)
                // metute method of picManager
                || mainException.GetType() == typeof(ObjectDisposedException)
                 )
            {
                logger.Error(AddTraceToMessage(mainException, null));
                await HandleExceptionAsync(context, ex.Message,statusCode);
            }
            else
            {
                logger.Error(AddTraceToMessage(mainException, null));
                await HandleExceptionAsync(context, ex.Message,statusCode);
            }
        }

        private async Task CheckDatabaseException(HttpContext context, Exception ex, Exception mainException,short statusCode)
        {
            ILogger logger = MyNLog.GetLogger(LoggerType.DatabaseExpLogger);
            if (mainException.GetType() == typeof(Microsoft.EntityFrameworkCore.DbUpdateException)
                || mainException.GetType() == typeof(Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException))
            {
                logger.Error(AddTraceToMessage(mainException, null));
                await HandleExceptionAsync(context, ex.Message,statusCode);
            }
            else
            {
                logger.Error(AddTraceToMessage(mainException, null));
                await HandleExceptionAsync(context, ex.Message,statusCode);
            }
        }



        private async Task CheckCommonException(HttpContext context, Exception ex,short statusCode)
        {
            await HandleExceptionAsync(context, ex.Message,statusCode);
        }

        private async Task CheckOtherException(HttpContext context, Exception ex)
        {
            ILogger logger = MyNLog.GetLogger(LoggerType.OtherExpLogger);
            string message = AddTraceToMessage(ex, null);
            logger.Error(message);
            if(message.StartsWith("Connection Timeout Expired"))
            {
                await HandleExceptionAsync(context, "Connection Timeout",(short)HttpStatusCode.BadRequest);
            }
            else
            {
                await HandleExceptionAsync(context, "500 server error",(short)HttpStatusCode.BadRequest);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, string message,short statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(new ResultDto
            {
                IsSuccess = false,
                Message = message
            }.ToString());
        }

        private string AddTraceToMessage(Exception mainException, IdentityDto<long> identityDto)
        {
            string identity = null;
            if (identityDto != null)
            {
                identity = "{id:" + identityDto.Id + " ,entity:" + identityDto.Entity + " ,entityId:" + identityDto.EntityId + "}";
            }
            var traceSubString = "";
            if (!string.IsNullOrEmpty(mainException.StackTrace))
            {
                var startIndex = mainException.StackTrace.IndexOf(" in ");
                var endtIndex = mainException.StackTrace.IndexOf(" at ", startIndex);
                if (endtIndex == -1)
                {
                    endtIndex = (mainException.StackTrace.Length - 1);
                }
                traceSubString = mainException.StackTrace.Substring(startIndex, endtIndex - startIndex);
            }
            var newMessage = identity + mainException.Message + traceSubString;
            return newMessage;
        }

        // based on type of exp and callerMethodName


    }
}

