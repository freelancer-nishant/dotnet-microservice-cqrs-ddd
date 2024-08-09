using User.Application.Constants.Messages.UserMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(UserMessage.EmailRequired)
                .MaximumLength(256).WithMessage(UserMessage.EmailExceeded)
                .EmailAddress().WithMessage(UserMessage.EmailIsNotValid);

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(UserMessage.FirstNameRequired)
                .NotNull().WithMessage(UserMessage.FirstNameRequired)
                .MaximumLength(128).WithMessage(UserMessage.FirstNameExceeded);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(UserMessage.LastNameRequired)
                .NotNull().WithMessage(UserMessage.LastNameRequired)
                .MaximumLength(128).WithMessage(UserMessage.LastNameExceeded);
        }
    }
}
