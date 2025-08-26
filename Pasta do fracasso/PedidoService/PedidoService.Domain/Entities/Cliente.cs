using PedidoService.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        // Value Objects
        public Telefone Telefone { get; private set; }
        public CPF Cpf { get; private set; }
        public Email Email { get; private set; }

        // Construtor para criação
        public Cliente(Guid id, string nome, CPF cpf, Email email, Telefone telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            Id = id == Guid.Empty ? Guid.NewGuid() : id;
            Nome = nome;
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
        }

        // Construtor privado para ORM (EF Core)
        private Cliente() { }
    }
}
