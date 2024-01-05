using System;
using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .WithMessage("O título é obrigatório.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255)
                .WithMessage("A descrição é obrigatória. Deve conter no máximo 255 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0)
                .WithMessage("O custo total deve ser maior que zero.");
        }
    }
}
