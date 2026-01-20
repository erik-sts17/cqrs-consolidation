using CQRS.Application.Members.Commands;
using CQRS.Application.Members.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetMembersQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetMemberByIdQuery
            {
                Id = id
            };
            var member = await _mediator.Send(query);
            return member != null ? Ok(member) : NotFound("Member Not Found");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberCommand command)
        {
            var member = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Create(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var member = await _mediator.Send(command);
            return member != null ? Ok(member) : NotFound("Member Not Found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, DeleteMemberCommand command)
        {
            command.Id = id;
            var member = await _mediator.Send(command);
            return member != null ? Ok(member) : NotFound("Member Not Found");
        }
    }
}