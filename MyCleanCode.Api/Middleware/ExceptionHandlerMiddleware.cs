﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCleanCode.Application.Exceptions;
using Newtonsoft.Json;
using ValidationException = FluentValidation.ValidationException;

namespace MyCleanCode.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
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
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    break;
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                default:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;

            if (result == string.Empty)
                result = JsonConvert.SerializeObject(new {error = exception.Message});

            return context.Response.WriteAsync(result);
        }
    }
}