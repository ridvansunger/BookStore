using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Common;

namespace WebApi.BookOperations.GetBookDetail
{  
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        public int BookId {get; set;}
        public GetBookDetailQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public BookDetailViewModel Handle()
        {
            var book=_dbcontext.Books.Where(book=>book.Id==BookId).SingleOrDefault();
            if(book is null)
                throw new InvalidOperationException ("Kitap bulunamadı"); 

            BookDetailViewModel vm=new BookDetailViewModel();
            vm.Title=book.Title;
            vm.PageCount=book.PageCount;
            vm.Genre=((GenreEnum)book.GenreId).ToString();
            vm.PublishDate=book.PublishDate.Date.ToString("dd/MM/yyyy");

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