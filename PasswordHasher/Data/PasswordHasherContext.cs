using Microsoft.EntityFrameworkCore;
using PasswordHasher.Models;

namespace PasswordHasher.Data
{
    public class PasswordHasherContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public PasswordHasherContext(DbContextOptions<PasswordHasherContext> options) : base(options)
        {
        }
    }
}
