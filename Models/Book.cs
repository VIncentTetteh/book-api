using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int Year { get; set; }
    }
}