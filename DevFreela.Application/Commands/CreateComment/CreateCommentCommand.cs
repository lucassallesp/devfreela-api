using System;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<ProjectComment>
    {
        public int IdProject { get; set; }
        public string Content { get; set; }
        public int IdUser { get; set; }
    }
}
