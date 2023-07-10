using FluentValidation;
using UnitOfWork.Architecture.Domain.Entities;

namespace UnitOfWork.Architecture.Application.Validators;

public class PersonValidator : AbstractValidator<Person>
{
	public PersonValidator()
	{
		RuleFor(p => p.FirstName)
			.NotEmpty().WithMessage("فیلد نام الزامی می باشد");

        RuleFor(p => p.LastName)
            .NotEmpty().WithMessage("فیلد نام خانوادگی الزامی می باشد");
    }
}
