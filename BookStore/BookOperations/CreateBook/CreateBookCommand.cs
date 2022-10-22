using AutoMapper;
using System;
using System.Linq;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        // create metodu yaparken dışarıdan bir parametre gönderiyoruz. o parametreyi Modelden alıyoruz Handle metodu için.
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var book = dbContext.Books.SingleOrDefault(x => x.Title == Model.Title); // Gelen kitap listede var mı diye baktık
            if (book is not null)
                throw new InvalidOperationException("Kitap mevcut");
            book = mapper.Map<Book>(Model); // Model ile gelen verileri book obj convert et.
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
