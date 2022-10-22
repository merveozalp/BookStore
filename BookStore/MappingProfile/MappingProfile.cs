using AutoMapper;
using BookStore.BookOperations.GetBooks;
using BookStore.Common;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.GetBooks.GetBooksQuery;
using static BookStore.BookOperations.GetByIdBook.GetByIdBookQuery;

namespace BookStore.MappingProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); ;
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetByIdViewModel>().ForMember(dest => dest.GenreName, opt=>opt.MapFrom(src=> ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
