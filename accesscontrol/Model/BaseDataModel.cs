using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Model
{
    public class BaseDataModel : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}