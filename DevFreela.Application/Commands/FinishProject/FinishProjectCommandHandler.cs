using System;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly IProjectRepository _projectRepository;

        public FinishProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id);
            if(project == null)
            {
                return false;
            }

            project.Finish();
            
            if(await _projectRepository.SaveChangesAsync())
            {
                return true;
            }

            return false;
        }
    }
}
