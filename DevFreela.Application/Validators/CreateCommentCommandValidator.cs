using System;
using DevFreela.Application.Commands.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(c => c.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255)
                .WithMessage("O comentário deve possuir no máximo 255 caracteres.");
        }
    }
}
