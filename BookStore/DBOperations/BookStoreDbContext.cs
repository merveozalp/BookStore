using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class BookStoreDbContext:DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
