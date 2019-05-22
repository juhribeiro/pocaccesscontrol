using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Model
{
    public class RoleGroupModel : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string RoleCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string GroupCode { get; set; }
    }
}