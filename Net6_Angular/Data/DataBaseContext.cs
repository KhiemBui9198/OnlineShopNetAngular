using Microsoft.EntityFrameworkCore;
using Net6_Angular.Models;

namespace Net6_Angular.Data
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
          { }
        public DbSet<Contact> Contacts { get; set; }
    }
}
