using System;
using DevFreela.Application.Commands.UpdateProject;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("A descrição deve possuir no máximo 255 caracteres.");

            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(30)
                .WithMessage("O título é obrigatório e deve possuir no máximo 30 caracteres.");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0)
                .WithMessage("O custo total deve ser maior que zero.");
        }
    }
}
