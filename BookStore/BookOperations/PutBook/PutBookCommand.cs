using System;
using System.Linq;

namespace BookStore.BookOperations.PutBook
{
    public class PutBookCommand
    {
        public PutModel Model {get;set;}
        public int BookId { get; set; }
        private readonly BookStoreDbContext dbContext;

        public PutBookCommand(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Handle()
        {
            PutModel model = new PutModel();
            var book = dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Güncelleme Kontrol Ediniz");
            }
            book.Title = model.Title != default ? model.Title : book.Title;
            //book.GenreId = model.GenreId != default ? model.GenreId : book.GenreId;
            book.PageCount = model.PageCount != default ? model.PageCount : book.PageCount;
            //book.PublishDate = model.PublishDate != default ? model.PublishDate : book.PublishDate;
            dbContext.SaveChanges();

        }

        public class PutModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            //public DateTime PublishDate { get; set; }
            //public int GenreId { get; set; }
        }
    }
}
