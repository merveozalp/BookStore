using System;
using System.Linq;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
       
        public int BookId { get; set; }
        private readonly BookStoreDbContext dbContext;

        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Handle()
        {
            var book = dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Aranan Kitap bulunamadı");
            }
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();

        }

       
                        
    }
}
