using FluentValidation;
using WebApi.Application.GenreOperations.DeleteGenre;

namespace WebApi.GenreOperations.DeleteGEnre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(x=>x.GenreId).GreaterThan(0);
        }
    }
}
