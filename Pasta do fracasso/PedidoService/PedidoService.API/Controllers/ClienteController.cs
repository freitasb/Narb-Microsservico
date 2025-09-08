using MediatR;
using Microsoft.AspNetCore.Mvc;
using PedidoService.Application.Commands.CriarCliente;

namespace PedidoService.API.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarClienteCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { ClienteId = id });
        }
    }
}
