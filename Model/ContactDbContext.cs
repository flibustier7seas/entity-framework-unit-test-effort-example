using System.Data.Entity;

namespace EntityFrameworkEffort.Model
{
    internal class ContactDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}