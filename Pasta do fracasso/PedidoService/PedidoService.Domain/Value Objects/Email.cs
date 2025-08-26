using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PedidoService.Domain.Value_Objects
{
    public record Email
    {
        public string Endereco { get; }

        public Email(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("E-mail é obrigatório.");

            if (!Regex.IsMatch(endereco, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Formato de e-mail inválido.");

            Endereco = endereco;
        }

        public override string ToString() => Endereco;

        public override int GetHashCode() => Endereco.GetHashCode();
    }
}
