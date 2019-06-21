using System.Collections.Generic;

namespace accesscontrol.Model
{
    public class RegisterApplicationModel
    {
        public RegisterApplicationModel()
        {
            this.Roles = new List<RoleModel>();
        }

        public virtual ApplicationModel Application { get; set; }
        public virtual List<RoleModel> Roles { get; set; }
    }
}