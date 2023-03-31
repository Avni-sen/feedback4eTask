using feedback4eTask.Entities.Concrete;
using FluentValidation;

namespace feedback4eTask.Business.Handlers.Airports.Validators
{
    public class AirportValidator : AbstractValidator<Airport>
    {
        //burada mesaj kısımları ayrı bir klasörleme ile daha clean bir şekilde düzenlenebilir.
        //istenirse Update ve Create Commands için ayrı ayrı validatorslar oluşturulabilir.
        public AirportValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id değeri boş bırakılamaz.");
        }
    }
}
