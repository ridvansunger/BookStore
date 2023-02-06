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
using WebApi.BookOperations.DeleteBook;
using AutoMapper;
using FluentValidation.Results;
using FluentValidation;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController:ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public object DeleteCommandBook { get; private set; }

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetBooks()
        {
           // var bookList=_context.Books.OrderBy(x=>x.Id).ToList<Book>();
            GetBooksQuery query=new GetBooksQuery(_context,_mapper);
            var result= query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            GetBookDetailQuery query=new GetBookDetailQuery(_context,_mapper);
            query.BookId=id;
            GetBookDetailQueryValidator validator=new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
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
            CreateBookComand comand=new CreateBookComand(_context,_mapper);
          
            comand.Model=newBook;
            CreateBookComandValidator validator=new CreateBookComandValidator();
            validator.ValidateAndThrow(comand);
            comand.Handle();

                // ValidationResult result= validator.Validate(comand);
                // if(!result.IsValid)
                //     foreach (var item in result.Errors)
                //         System.Console.WriteLine("Özellik"+item.PropertyName+" - Error Message: "+item.ErrorMessage);
                // else
                //     comand.Handle();
         
            return Ok();
        }

        //put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id,[FromBody] UpdateBookModel updateBook)
        {
            UpdateBookCommand command=new UpdateBookCommand(_context);
            command.BookId=id;
            command.Model=updateBook;
                 
            UpdateBookCommandValidator validator=new UpdateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        //delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command=new DeleteBookCommand(_context);
            command.BookId=id;
            DeleteBookCommandValidator validator=new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
           
            return Ok();
        }
    }
}