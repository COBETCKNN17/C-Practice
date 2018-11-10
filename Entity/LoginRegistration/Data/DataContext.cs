using LoginRegistration.Models;
using LoginRegistration.ViewModels; 
using Microsoft.EntityFrameworkCore;

namespace LoginRegistration.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<RegistrationViewModel> RegView { get; set; }
    }
}