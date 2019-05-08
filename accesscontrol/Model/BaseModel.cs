using System;
using Newtonsoft.Json;

namespace accesscontrol.Model
{
    public class BaseModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        public string CreateUser { get; set; }

        public string LastChangeUser { get; set; }
    }
}