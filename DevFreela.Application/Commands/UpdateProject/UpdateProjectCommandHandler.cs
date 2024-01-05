using System;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Project>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);
            _projectRepository.Update(project);
            
            if(await _projectRepository.SaveChangesAsync())
            {
                return project;
            }

            return null;
        }
    }
}
