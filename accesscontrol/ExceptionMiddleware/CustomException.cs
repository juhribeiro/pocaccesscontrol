using System;

namespace accesscontrol.ExceptionMiddleware
{
    public class CustomException : Exception
    {
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