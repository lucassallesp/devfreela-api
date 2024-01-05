using System;
using System.Data;
using System.Text.RegularExpressions;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("E-mail inválido");

            RuleFor(u => u.Password)
                .Must(ValidatePassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra minúscula e uma letra maiúscula");

            RuleFor(u => u.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome completo é obrigatório");
        }

        public bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");

            return regex.IsMatch(password);
        }
    }

    

}
