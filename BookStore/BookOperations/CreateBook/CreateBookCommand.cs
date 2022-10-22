using System;
using System.Linq;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        // create metodu yaparken dışarıdan bir parametre gönderiyoruz. o parametreyi Modelden alıyoruz Handle metodu için.
        public CreateBookModel Model { get; set; }
        private BookStoreDbContext dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Handle()
        {
            var book = dbContext.Books.SingleOrDefault(x => x.Title == Model.Title); // Gelen kitap listede var mı diye baktık
            if (book is not null)
                throw new InvalidOperationException("Kitap mevcut");
            book = new PutBookModel();
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PublishDate = Model.PublishDate;
            book.PageCount= Model.PageCount;
            
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            
           
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}
