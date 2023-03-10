using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOprations.Queries 
{
    public class GetAuthorQuery
    {
        private readonly BookStoreDbContext _context;
          private readonly IMapper _mapper;

        public GetAuthorQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors=_context.Authors.Include(a=>a.Book).OrderBy(x=>x.ID).ToList();
            List<AuthorViewModel> values=_mapper.Map<List<AuthorViewModel>>(authors);
            return values;
        }

      
    }


    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int BookId { get; set; }
    }
}