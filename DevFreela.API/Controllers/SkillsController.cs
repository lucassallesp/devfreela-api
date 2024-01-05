using System;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Authorize]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllSkillsQuery = new GetAllSkillsQuery();

            var skills = await _mediator.Send(getAllSkillsQuery);

            return Ok(skills);
        }
    }
}
