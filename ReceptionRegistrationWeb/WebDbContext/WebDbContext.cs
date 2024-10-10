using Microsoft.EntityFrameworkCore;
using ReceptionRegistrationWeb.Models;
using System.Xml.Linq;

namespace ReceptionRegistrationWeb.WebDbContext
{
    public class WebDbContext : DbContext
    {
        public DbSet<Admin> tblAdmins { get; set; }
        public DbSet<ShowroomCustomer> tblShowroomCustomers { get; set; }
        public DbSet<CallRecorderCustomer> tblCallRecorderCustomers { get; set; }

        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Comments> Comments { get; set; }

        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<News>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.News)
            //    .HasForeignKey(c => c.NewsId);

            //modelBuilder.Entity<Category>()
            //    .HasMany(c => c.News)
            //    .WithOne(a => a.Category)
            //    .HasForeignKey(a => a.CategoryId);

            //modelBuilder.Entity<Users>()
            //    .HasMany(u => u.Comments)
            //    .WithOne(c => c.User)
            //    .HasForeignKey(c => c.UserId);

        }

    }
}
