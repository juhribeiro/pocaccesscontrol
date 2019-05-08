using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Data
{
    public class Group : BaseData
    {
        public Group()
        {
            this.UserGroups = new List<UserGroup>();
            this.RoleGroups = new List<RoleGroup>();
        }

        public List<UserGroup> UserGroups { get; set; }

        public List<RoleGroup> RoleGroups { get; set; }

        [ForeignKey(nameof(Application))]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}