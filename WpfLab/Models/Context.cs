using System.Data.Entity;

namespace WpfLab.Models
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }

        public DbSet<Reader> Readers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Issuance> Issuances { get; set; }
    }
}
