using FluentValidation;
using WebApi.Application.GenreOperations.CreateGenre;

namespace WebApi.GenreOperations.CreateGenre
{
    public class CreateGenreComandValidator:AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreComandValidator()
        {
            RuleFor(x=>x.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}