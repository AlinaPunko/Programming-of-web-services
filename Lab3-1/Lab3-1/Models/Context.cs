using System.Data.Entity;

namespace Lab3_1.Models
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}