
using ASAPSystem.Assignment.Core.Models;
using Microsoft.EntityFrameworkCore;


namespace ASAPSystem.Assignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }


    }
}
