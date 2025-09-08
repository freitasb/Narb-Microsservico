using PedidoService.Application.Interfaces;
using PedidoService.Domain.Entities;
using PedidoService.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Commands.CriarCliente
{
    public class CriarClienteCommandHandler
    {
        private readonly IRepository<Cliente> _repository;

        public CriarClienteCommandHandler(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cpf = new CPF(request.Cpf);
            var email = new Email(request.Email);
            var telefone = new Telefone(request.Telefone);

            // 1. Criar a entidade Cliente
            var cliente = new Cliente(
                Guid.NewGuid(),
                request.Nome,
                cpf,
                email,
                telefone
            );

            // 2. Salvar no banco via Repository
            await _repository.AddAsync(cliente);

            // 3. Retornar Id do cliente criado
            return cliente.Id;
        }
    }
}
