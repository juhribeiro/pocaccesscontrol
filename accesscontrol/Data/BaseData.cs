using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Data
{
    public class BaseData : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}