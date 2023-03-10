using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOprations;
using WebApi.Application.AuthorOprations.Queries;
using WebApi.DbOperations;
using WebApi.Validator.AuthorValidator;
using WebApi.Validator.GenreValidator;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;

namespace WebApi.AddController
{ 
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthor()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context,_mapper);
            var authors = query.Handle();
            return Ok(authors);
        }
         [HttpGet("id")]
        public ActionResult GetByIdAuthor(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId = id;

            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            validator.ValidateAndThrow(query);


            var author = query.Handle(); 
            return Ok(author);

        }

         [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
        {
           
                CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
                command.Model = model;

                CreateAuthorValidator validator =  new CreateAuthorValidator();
                validator.ValidateAndThrow(command);
                
                command.Handle();
                return Ok();

           

        }

         [HttpPut("{id}")]
            public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
            {
               
                    UpdateAuthor command = new UpdateAuthor();
                    command.AuthorID = id;
                    command.Model = model;

                    UpdateAuthorValidator validator = new UpdateAuthorValidator();
                    validator.ValidateAndThrow(command);

                    command.Handle();
                    return Ok();

            }

            [HttpDelete("{id}")]
            public IActionResult DeleteAuthor(int id)
            {
                
                DeleteAuthor command = new DeleteAuthor(_context);
                command.AuthorId = id;

                DeleteAuthorValidator validator = new DeleteAuthorValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
                return Ok();
                
            }

    }
}
