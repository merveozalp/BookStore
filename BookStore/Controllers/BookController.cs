using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetByIdBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.GetByIdBook.GetByIdBookQuery;
using static BookStore.BookOperations.PutBook.PutBookCommand;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext dbContext;
        private readonly IMapper mapper;
        public BookController(BookStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // static olmalı çünkü program çalıştıı srece lifecycle çalışmalı.
        //private static List<Book> BookList = new List<Book>()
        //{
        //    new Book
        //    {
        //        Id=1,
        //        Title="Çalıkuşu",
        //        GenreId=1,
        //        PageCount=200,
        //        PublishDate=new DateTime(2001,06,12)

        //    },
        //    new Book
        //    {
        //        Id=2,
        //        Title="Suç Ve Ceza",
        //        GenreId=1,
        //        PageCount=200,
        //        PublishDate=new DateTime(2001,06,12)

        //    },
        //    new Book
        //    {
        //        Id=3,
        //        Title="Outlife",
        //        GenreId=1,
        //        PageCount=200,
        //        PublishDate=new DateTime(2001,06,12)

        //    }


        //};
        [HttpGet]

        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(dbContext,mapper);
            var result= query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdViewModel result;
            GetByIdBookQuery query = new GetByIdBookQuery(dbContext, mapper);
            try
            {
                query.BookId = id;
               result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);

        }


        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookModel newbook)
        {
            CreateBookCommand bookCommand = new CreateBookCommand(dbContext,mapper);
            try
            {
                bookCommand.Model = newbook;
                bookCommand.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
           
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult EditBook(int id, [FromBody] PutModel updatebook)
        {
            //var  book = dbContext.Books.SingleOrDefault(x=>x.Id==id);
            //if (book is null)
            //{
            //    return BadRequest();
            //}
            //book.Title=updatebook.Title != default ? updatebook.Title :book.Title;
            //book.GenreId = updatebook.GenreId != default ? updatebook.GenreId : book.GenreId;
            //book.PageCount=updatebook.PageCount != default ? updatebook.PageCount : book.PageCount;
            //book.PublishDate = updatebook.PublishDate != default ? updatebook.PublishDate : book.PublishDate;
            //dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = dbContext.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
