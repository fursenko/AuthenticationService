using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.DataAccess
{
    public class UserRole
    {
        //[ForeignKey("User")]
        //[Column("SecurityUserId")]
        public int UserId { get; set; }

        
        //[Column("SecurityUserId")]
        //[ForeignKey("User")]
        public int RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
