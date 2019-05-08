using System;
using System.Collections.Generic;

namespace accesscontrol.Model
{
    public class SecurityModel
    {
        public string Token { get; set; }

        public DateTime ExpirateIn { get; set; }
        
        public string Email { get; set; }
        
        public List<string> Permissions { get; set; }
    }
}