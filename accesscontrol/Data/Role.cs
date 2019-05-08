
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Data
{
    public class Role : BaseData
    {
        public Role()
        {
            this.RoleGroups = new List<RoleGroup>();
        }

        public List<RoleGroup> RoleGroups { get; set; }
    }
}