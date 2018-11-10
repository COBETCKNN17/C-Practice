using Microsoft.EntityFrameworkCore;
 
namespace LoginRegistration.Models
{
    public class DataContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> users {get; set;}
        public DbSet<Login> login {get; set;}
    }
}
