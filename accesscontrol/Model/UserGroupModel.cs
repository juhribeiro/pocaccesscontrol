using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Model
{
    public class UserGroupModel : BaseModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int GroupId { get; set; }
    }
}