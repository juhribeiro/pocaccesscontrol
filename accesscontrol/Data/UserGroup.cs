using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Data
{
    public class UserGroup : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}