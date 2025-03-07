using BookMVCYayin.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMVCYayin.Context
{
    public class BookDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=MSA; database=BookMVCYayin; Integrated Security=True; TrustServerCertificate=True");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
