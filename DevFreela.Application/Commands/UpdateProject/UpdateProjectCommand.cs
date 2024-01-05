using System;
using DevFreela.Application.InputModels;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Project>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
