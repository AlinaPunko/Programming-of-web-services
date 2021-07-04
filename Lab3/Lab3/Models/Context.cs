using System.Data.Entity;

namespace Lab3.Models
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}