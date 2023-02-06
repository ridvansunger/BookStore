
using FluentValidation;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;



namespace WebApi.Validator.AuthorValidator
{

    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {

      public CreateAuthorValidator()
      {

        RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.LastName).MinimumLength(2).NotEmpty();
        RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);
        
      }
      
    }
}