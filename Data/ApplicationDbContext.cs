using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web_satky.Models;

namespace web_satky.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<web_satky.Models.Blog> Blog { get; set; } = default!;
        public DbSet<web_satky.Models.Product> Product { get; set; } = default!;
    }

    
}
