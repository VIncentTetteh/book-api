using Microsoft.EntityFrameworkCore;
using BooksAPI.Models;

namespace BooksAPI.Data
{
   public class AppDbContext : DbContext
   {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

      public DbSet<Book> Books { get; set; }
   }
}