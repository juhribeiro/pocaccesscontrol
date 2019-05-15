using accesscontrol.Enums;
using Newtonsoft.Json;

namespace accesscontrol.ExceptionMiddleware
{
    public class MessageDetails
    {
        public MessageType Type { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
 
 
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}