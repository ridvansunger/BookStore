using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.CreateBook;
using static WebApi.BookOperations.CreateBook.CreateBookComand;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetBooks()
        {
           // var bookList=_context.Books.OrderBy(x=>x.Id).ToList<Book>();
            GetBooksQuery query=new GetBooksQuery(_context);
            var result= query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query=new GetBookDetailQuery(_context);
                query.BookId=id;
                result=query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok(result);

        }

        
        // [HttpGet("{id}")]
        // public Book Get([FromQuery] string id)
        // {
        //     var book=BookList.Where(book=>book.Id==Convert.ToInt32(id)).SingleOrDefault();

        //     return book;

        // }


        //post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookComand comand=new CreateBookComand(_context);

            try
            {
                comand.Model=newBook;
                comand.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok();
        }

        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            try
            {
                
                 UpdateBookCommand command=new UpdateBookCommand(_context);
                 command.BookId=id;
                 command.Model=updateBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
            return Ok();
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book= _context.Books.SingleOrDefault(x=>x.Id==id);
            if(book is null)
            {
                return BadRequest();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
            
        }

    }
}