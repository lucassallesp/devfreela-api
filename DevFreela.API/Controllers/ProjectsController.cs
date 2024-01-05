using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectService projectService, IMediator mediator)
        {
            _projectService = projectService;
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> Get(string query)
        {
            var getAllProjectsQuery = new GetAllProjectsQuery(query);

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }

        [HttpPost]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if(command.Title.Length > 50)
            {
                return BadRequest();
            }

            // var id = _projectService.Create(newProjectInputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id}, command);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> GetById(int id)
        {
            var getProjectByIdQuery = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(getProjectByIdQuery);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectInputModel model)
        {
            if(model.Description.Length > 200)
            {
                return BadRequest();
            }

            var command = new UpdateProjectCommand
            {
                Id = id,
                Description = model.Description,
                Title = model.Title,
                TotalCost = model.TotalCost
            };

            var project = await _mediator.Send(command);
            if(project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Delete(int id)
        {
            var project = new DeleteProjectCommand(id);
            await _mediator.Send(project);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        [Authorize(Roles = "client, freelancer")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            var comment = await _mediator.Send(command);

            return Ok(comment);
        }

        [HttpPut("{id}/start")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Start(int id)
        {
            var project = new StartProjectCommand(id);
            await _mediator.Send(project);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize(Roles = "client")]
        public async Task<IActionResult> Finish(int id)
        {
            var project = new FinishProjectCommand(id);
            await _mediator.Send(project);

            return NoContent();
        }
    }
}
