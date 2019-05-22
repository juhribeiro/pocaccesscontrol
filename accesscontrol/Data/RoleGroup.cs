using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Data
{
    public class RoleGroup : BaseEntity
    {
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}