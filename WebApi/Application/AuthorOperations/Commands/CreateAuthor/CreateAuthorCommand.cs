using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel Model {get;set;}

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x=>x.Name == Model.Name && x.LastName==Model.LastName);
            if(author is not null)
                throw new InvalidOperationException("Author already exists");
            
         
            author=_mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public int BookId { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime PublisDate { get; set; }
        }




    }
}