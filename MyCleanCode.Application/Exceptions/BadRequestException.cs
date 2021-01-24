using System;
using System.ComponentModel.DataAnnotations;

namespace MyCleanCode.Application.Exceptions
{
    // Use when we encounter wrong input
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }

    // When don't find the element    
}