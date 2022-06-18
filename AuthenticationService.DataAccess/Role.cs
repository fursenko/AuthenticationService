using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationService.DataAccess
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public virtual ICollection<User> Users { get; set; }
    }
}
