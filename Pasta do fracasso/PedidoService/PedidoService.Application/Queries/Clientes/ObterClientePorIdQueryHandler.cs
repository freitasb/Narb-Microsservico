using MediatR;
using PedidoService.Application.DTOs;
using PedidoService.Application.Interfaces;
using PedidoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Queries.Clientes
{
    public class ObterClientePorIdQueryHandler : IRequestHandler<ObterClientePorIdQuery, ClienteDTO>
    {
        private readonly IRepository<Cliente> _repository;

        public ObterClientePorIdQueryHandler(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<ClienteDTO> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetByIdAsync(request.ClienteId);

            if (cliente == null) return null;

            return new ClienteDTO
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf.Numero,
                Email = cliente.Email.Endereco,
                Telefone = cliente.Telefone.Numero
            };
        }
    }
}
