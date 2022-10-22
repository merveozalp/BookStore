using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.GetByIdBook;
using BookStore.BookOperations.PutBook;
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
        public BookController(BookStoreDbContext dbContext)
        {
            this.dbContext=dbContext;

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
            GetBooksQuery query = new GetBooksQuery(dbContext);
            var result= query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GetByIdViewModel result;
           
            try
            {
                GetByIdBookQuery query = new GetByIdBookQuery(dbContext);
                query.BookId=id;
                result =query.Handle();

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
            CreateBookCommand bookCommand = new CreateBookCommand(dbContext);
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
            PutBookCommand putBookCommand = new PutBookCommand(dbContext);
            try
            {
                putBookCommand.BookId = id;
                putBookCommand.Model = updatebook;
                putBookCommand.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(dbContext);
            try
            {
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
