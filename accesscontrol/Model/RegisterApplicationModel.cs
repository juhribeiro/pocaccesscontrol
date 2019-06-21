using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Model
{
    public class RegisterApplicationModel
    {
        public RegisterApplicationModel()
        {
            this.Roles = new List<RoleModel>();
        }

        [Required]
        public virtual ApplicationModel Application { get; set; }

        [Required]
        public virtual List<RoleModel> Roles { get; set; }
    }
}