using AutoMapper;
using BookStore.Common;
using System;
using System.Linq;

namespace BookStore.BookOperations.GetByIdBook
{
    public class GetByIdBookQuery
    {
        public int BookId { get; set; }

        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;

        public GetByIdBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public GetByIdViewModel Handle()
        {
            var book = dbContext.Books.Where(c => c.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }
            GetByIdViewModel vm =mapper.Map<GetByIdViewModel>(book);
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
