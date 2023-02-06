using AutoMapper;
using WebApi.Application.AuthorOprations.Queries;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.Application.AuthorOperations.Commands.CreateAuthor.CreateAuthorCommand;
using static WebApi.BookOperations.CreateBook.CreateBookComand;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();

            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));

            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));
            
            CreateMap<Genre,GenreViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();

            CreateMap<CreateAuthorModel,Author>();
            CreateMap<Author,CreateAuthorModel>();
             CreateMap<Author , AuthorDetailViewModel>()
            .ForMember(dest => dest.Book , opt=> opt.MapFrom(src => src.Book.Title));

            CreateMap<AuthorViewModel,Author>();
            CreateMap<Author,AuthorViewModel>();
        }
    }
}
