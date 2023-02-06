using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations
{
    public class UpdateAuthor
    {
         private readonly BookStoreDbContext _context;
        public int AuthorID { get; set; } 
        public UpdateAuthorModel Model {get; set;}

        public void Handle()
        {
            var author=_context.Authors.SingleOrDefault(x => x.ID == AuthorID);
            if(author is null)
             throw new InvalidOperationException("GÜncellencek yazar bulunamadı");

            author.BookId =Model.BookId != default ? Model.BookId : author.BookId;
            author.Name =Model.Name != default ? Model.Name : author.Name;
            author.LastName =Model.LastName != default ? Model.LastName : author.LastName;

            _context.SaveChanges();
        }

    }

    public class UpdateAuthorModel
    {
         public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
