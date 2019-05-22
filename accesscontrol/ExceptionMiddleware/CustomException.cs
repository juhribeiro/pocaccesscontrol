using System;

namespace accesscontrol.ExceptionMiddleware
{
    public class CustomException : Exception
    {
        private readonly MessageDetails message;

        public CustomException(MessageDetails message)
        : base(message.ToString())
        {
        }

        public CustomException(MessageDetails message, Exception inner)
         : base(message.ToString(), inner)
        {
        }
    }
}