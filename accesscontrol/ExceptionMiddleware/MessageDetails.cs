using accesscontrol.Enums;
using Newtonsoft.Json;

namespace accesscontrol.ExceptionMiddleware
{
    public class MessageDetails
    {
        public MessageDetails(MessageType type, string message)
        {
            Type = type;
            Message = message;
        }

        public MessageType Type { get; set; }
        public string Message { get; set; }
 
 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}