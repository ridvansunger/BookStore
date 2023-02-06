
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations
{
    public class DeleteAuthor
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthor(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author=_context.Authors.Include(a=>a.Book).SingleOrDefault(x=>x.ID==AuthorId);
            if(author is null)
                throw new InvalidOperationException("Authoe is not find");

            // var authorsbook=_context.Books.Where(x=>x.AuthorId==author.ID).Any();
            //     if(authorsbook != null)
            //         throw new InvalidOperationException("Yazarın kayıtlı kitabı var silinemez");

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
