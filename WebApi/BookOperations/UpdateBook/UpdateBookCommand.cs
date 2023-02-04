using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Common;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId { get; set; }
        public UpdateBookModel Model;
        public UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
             var book= _context.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
                throw new InvalidOperationException ("Güncellencek kitap bulunamadı");

            book.GenreId=Model.GenreId!=default ? Model.GenreId:book.GenreId;
            book.Title=Model.Title!=default?Model.Title:book.Title;

            _context.SaveChanges();
        }

        public class UpdateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
        }
    }

}