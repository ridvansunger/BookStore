using FluentValidation;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookComandValidator:AbstractValidator<CreateBookComand>
    {
        public CreateBookComandValidator()
        {
            //Sıfırdan büyük olmalı
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            //Sıfırdan büyük olmalı
            RuleFor(command=>command.Model.PageCount).GreaterThan(0);
            //Boş olamaz ve bugunub tarihi olamaz.
            RuleFor(command=>command.Model.PublishDate.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
            //Boş olamaz ve 4 karakterten küçük olamaz.
            RuleFor(commad=>commad.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}