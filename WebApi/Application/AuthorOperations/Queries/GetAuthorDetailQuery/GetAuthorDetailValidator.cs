using FluentValidation;
using WebApi.Application.AuthorOprations.Queries;


namespace WebApi.Validator.GenreValidator
{

    public class GetAuthorDetailValidator : AbstractValidator<GetAuthorDetailQuery>
    {

      public GetAuthorDetailValidator()
      {
        RuleFor(x => x.AuthorId).GreaterThan(0);
      }
        
      
    }
}
        