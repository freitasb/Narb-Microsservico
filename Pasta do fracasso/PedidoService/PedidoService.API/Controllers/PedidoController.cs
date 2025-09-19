using MediatR;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Application.Commands.CriarCliente;
using PedidoService.Application.Commands.CriarPedido;

namespace PedidoService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarPedidoCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { PedidoId = id });
        }
    }
}
