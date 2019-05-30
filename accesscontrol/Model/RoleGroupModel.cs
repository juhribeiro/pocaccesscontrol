using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Model
{
    public class RoleGroupModel : BaseModel
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
}