using System;
using Newtonsoft.Json;

namespace accesscontrol.Model
{
    public class BaseModel
    {
        public int Id { get; private set; }

        public DateTime CreateDate { get; private set; }

        public string CreateUser { get; private set; }

        public DateTime LastChangeDate { get; private set; }

        public string LastChangeUser { get; private set; }

        public bool Active { get; set; }
    }
}