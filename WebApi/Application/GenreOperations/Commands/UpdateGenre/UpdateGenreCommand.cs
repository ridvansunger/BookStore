using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }

        private readonly BookStoreDbContext _context;

        public UpdateGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre=_context.Genres.SingleOrDefault(x=>x.Id==GenreId);
            if(genre is null)
                throw new InvalidOperationException("Kitap türü bulunamadı");

            if(_context.Genres.Any(x=>x.Name.ToLower()==Model.Name.ToLower() && x.Id !=GenreId))
                throw new InvalidOperationException("Aynı isimde bir kitap türü zaten var");

            genre.Name=string.IsNullOrEmpty(Model.Name.Trim())==default ? genre.Name : Model.Name;
            genre.IsActive=Model.IsActive;
            _context.SaveChanges();
                
        }
    }


    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
   
}