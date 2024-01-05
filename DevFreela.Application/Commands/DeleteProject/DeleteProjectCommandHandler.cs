using System;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;
        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id);

            project.Cancel();

            if(await _projectRepository.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }
    }
}
