using System;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IProjectRepository projectRepository, IAuthService authService)
        {
            _projectRepository = projectRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new User(
                request.FullName,
                request.Email,
                request.BirthDate,
                request.Role,
                passwordHash
            );

            _projectRepository.Add(user);
            await _projectRepository.SaveChangesAsync();
            
            return user.Id;
        }
    }
}
