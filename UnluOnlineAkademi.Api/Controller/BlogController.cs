using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnluOnlineAkademi.Application.Blog.Commands.CreateBlogCommand;
using UnluOnlineAkademi.Application.Blog.Commands.DeleteBlogCommand;
using UnluOnlineAkademi.Application.Blog.Commands.UpdateBlogCommand;
using UnluOnlineAkademi.Application.Blog.Queries.BlogById;
using UnluOnlineAkademi.Application.Blog.Queries.BlogGetList;
using UnluOnlineAkademi.Application.Blog.Queries.WhyUsTop6List;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsList;
using UnluOnlineAkademi.Application.WhyUs.Queries.WhyUsTop6List;

namespace UnluOnlineAkademi.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/Blog
        [HttpGet]
        public async Task<ActionResult<List<BlogDto>>> GetAll(CancellationToken ct)
        {
            var list = await _mediator.Send(new GetBlogListQuery(), ct);
            return Ok(list);
        }

        // GET api/Blog/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BlogByIdDto>> GetById(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new BlogByIdQuery { ID = id }, ct);
            if (dto == null) return NotFound();
            return Ok(dto);
        }


        [HttpGet("last-three")]
        public async Task<ActionResult<List<BlogDto>>> GetLastThree(CancellationToken ct)
        {
            var items = await _mediator.Send(new BlogTop6ListQuery(), ct);
            return Ok(items);
        }

        // POST api/Blog
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBlogCommand command, CancellationToken ct)
        {
            var id = await _mediator.Send(command, ct);
            return CreatedAtAction(nameof(GetById), new { id = id }, id);
        }

        // PUT api/Blog/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            [FromBody] UpdateBlogCommand command,
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
            var command = new DeleteBlogCommand(id);
            var result = await _mediator.Send(command, ct);
            if (!result)
            {
                return NotFound("İlgili veri bulunamadı");
            }
            return NoContent();
        }
    }
}
