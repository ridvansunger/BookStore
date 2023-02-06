using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenreQuery
    {
        public readonly BookStoreDbContext _context;
           public readonly IMapper _mapper;
        public GetGenreQuery(BookStoreDbContext context = null, IMapper mapper = null)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres=_context.Genres.Where(x=>x.IsActive==true).OrderBy(x=>x.Id);
            List<GenreViewModel> returnObj=_mapper.Map<List<GenreViewModel>>(genres);
            return returnObj;
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}