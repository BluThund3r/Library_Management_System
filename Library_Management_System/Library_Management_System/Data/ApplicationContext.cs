using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class ApplicationContext: DbContext
    {


        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
