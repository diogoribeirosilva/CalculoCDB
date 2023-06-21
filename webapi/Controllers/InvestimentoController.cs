using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalculoCDB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestimentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{investimentoId}")]
        public async Task<ActionResult<InvestimentoDto>> ObterInvestimento(int investimentoId)
        {
            var query = new ObterInvestimentoQuery(investimentoId);
            var investimentoDto = await _mediator.Send(query);

            if (investimentoDto == null)
                return NotFound();

            return Ok(investimentoDto);
        }

        [HttpPost]
        public async Task<ActionResult<InvestimentoDto>> CalcularInvestimento([FromBody] CalcularInvestimentoCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var investimentoDto = await _mediator.Send(command);

            if (investimentoDto == null)
                return BadRequest();

            return Ok(investimentoDto);
        }
    }
}
