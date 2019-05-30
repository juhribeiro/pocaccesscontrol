using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Model
{
    public class UserApplicationModel : BaseModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int ApplicationId { get; set; }
    }
}