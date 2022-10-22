using BookStore.Common;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetByIdBook
{
    public class GetByIdBookQuery
    {
        public int BookId { get; set; }

        private BookStoreDbContext dbContext;

        public GetByIdBookQuery(BookStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public GetByIdViewModel Handle()
        {
            var book = dbContext.Books.Where(c => c.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            GetByIdViewModel vm = new GetByIdViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy");
            vm.GenreName = ((GenreEnum)book.GenreId).ToString();
            return vm;


        }

        public class GetByIdViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string GenreName { get; set; }
        }
    }
}
