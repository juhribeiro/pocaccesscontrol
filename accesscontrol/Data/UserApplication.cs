using System.ComponentModel.DataAnnotations.Schema;

namespace accesscontrol.Data
{
    public class UserApplication : BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        
        [ForeignKey(nameof(Application))]
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}