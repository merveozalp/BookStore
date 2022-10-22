using AutoMapper;
using BookStore.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext bookStore;
        private readonly IMapper mapper;
        public GetBooksQuery(BookStoreDbContext bookStore, IMapper mapper)
        {
            this.bookStore = bookStore;
            this.mapper = mapper;
        }
        public List<BookViewModel> Handle()
        {
            var booklist=bookStore.Books.OrderBy(x=>x.Id).ToList<Book>();
            List<BookViewModel> vm= mapper.Map<List<BookViewModel>>(booklist);
            //foreach (var book in booklist)
            //{
            //    vm.Add(new BookViewModel()
            //    {
            //        Title = book.Title,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
            //        PageCount= book.PageCount

            //    });
            //}
            return vm;
        }
        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }



        }
    }
}
