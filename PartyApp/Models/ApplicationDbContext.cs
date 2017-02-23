using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace PartyApp.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyType> PartyTypes { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
