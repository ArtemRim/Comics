using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;

namespace Comics.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [StringLength(5000, MinimumLength = 10)]
        public String Information { get; set; }
        [StringLength(1000, MinimumLength = 10)]
        public String PhotoURL { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Cartoon> Cartoons { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<PartDialog> PartDialogs { get; set; }
        public DbSet<DialogTemplate> DialogTemplates { get; set; }
        public DbSet<Voice> Voices { get; set; }
        public DbSet<PageTemplate> PageTemplates { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Page> Pages { get; set; }

    } 
}