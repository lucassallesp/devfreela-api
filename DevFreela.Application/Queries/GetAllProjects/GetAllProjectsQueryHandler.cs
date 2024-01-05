using System;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Enums;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;
        public GetAllProjectsQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllProjects();

            return projects
                .Where(p => p.Status != ProjectStatusEnum.Cancelled)
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();
        }
    }
}
