using System;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, ProjectComment>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateCommentCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        
        public async Task<ProjectComment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(
                request.Content,
                request.IdProject,
                request.IdUser
            );

            _projectRepository.Add(comment);
            await _projectRepository.SaveChangesAsync();

            return comment;
        }
    }
}
