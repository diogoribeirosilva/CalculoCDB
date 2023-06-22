using CalculoCDB.API.Validators;
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
        private readonly InvestimentoValidator _investimentoValidator;

        public InvestimentoController(IMediator mediator, InvestimentoValidator investimentoValidator)
        {
            _mediator = mediator;
            _investimentoValidator = investimentoValidator;
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
            var validationResult = await _investimentoValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var investimentoDto = await _mediator.Send(command);

            if (investimentoDto == null)
                return BadRequest();

            return Ok(investimentoDto);
        }
    }
}
