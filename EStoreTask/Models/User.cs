using Microsoft.AspNetCore.Identity;

namespace EStoreTask.Models
{
    public class User:IdentityUser
    {

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();

    }
}
