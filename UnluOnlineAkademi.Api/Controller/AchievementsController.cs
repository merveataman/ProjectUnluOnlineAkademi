using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.Achievements.Commands.CreateAchievementsCommand;
using UnluOnlineAkademi.Application.Achievements.Commands.DeleteAchievementsCommand;
using UnluOnlineAkademi.Application.Achievements.Commands.UpdateAchievementsCommand;
using UnluOnlineAkademi.Application.Achievements.Queries.AchievementsById;
using UnluOnlineAkademi.Application.Achievements.Queries.AchievementsGetList;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AchievementsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<AchievementsDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetAchievementsListQuery(), ct);
            return Ok(list);
        }

        // GET api/Achievements/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AchievementsByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new AchievementsByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        // POST api/Achievements
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAchievementsCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/Achievements/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateAchievementsCommand command,
            CancellationToken ct)
        {
            if (id != command.ID) return BadRequest("ID mismatch");
            var updated = await _mediator.Send(command, ct);
            if (!updated) return NotFound("İlgili kayıt bulunamadı");
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var command = new DeleteAchievementsCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
