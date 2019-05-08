using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Data
{
    public class Application : BaseData
    {
        public Application()
        {
            this.UserApplications = new List<UserApplication>();
            this.Groups = new List<Group>();
        }

        public List<UserApplication> UserApplications { get; set; }

        public List<Group> Groups { get; set; }
    }
}