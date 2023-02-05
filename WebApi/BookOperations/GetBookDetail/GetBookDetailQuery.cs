using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Common;
using AutoMapper;

namespace WebApi.BookOperations.GetBookDetail
{  
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public int BookId {get; set;}
        public GetBookDetailQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book=_dbcontext.Books.Where(book=>book.Id==BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException ("Kitap bulunamadı"); 

            BookDetailViewModel vm=_mapper.Map<BookDetailViewModel>(book); //new BookDetailViewModel();
            // vm.Title=book.Title;
            // vm.PageCount=book.PageCount;
            // vm.Genre=((GenreEnum)book.GenreId).ToString();
            // vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");

            return vm;
        }

    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}