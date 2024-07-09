using Microsoft.EntityFrameworkCore;
using PasswordManager.Core.Models;

namespace PasswordManager.DAL
{
    public class PasswordManagerDbContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options) 
            : base(options) 
        {

        }
    }
}
