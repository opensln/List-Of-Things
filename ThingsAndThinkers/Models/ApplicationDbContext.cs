using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ThingsAndThinkers.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ThingTBL> ThingTBLs { get; set; }
        public DbSet<ThingCategoryTBL> ThingCategoryTBLs { get; set; }

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