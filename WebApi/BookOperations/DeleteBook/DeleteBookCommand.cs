using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Common;

namespace WebApi.BookOperations.DeleteBook
{
    
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;
        public int BookId
         { get; set; }
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }


        public void Handle()
        {
             var book= _context.Books.SingleOrDefault(x=>x.Id==BookId);
            if(book is null)
                throw new InvalidOperationException ("Silinecek Kitap bulunamdı");
                
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

}