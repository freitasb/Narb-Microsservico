using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Domain.Value_Objects
{
    public record Telefone
    {
        public string Numero { get; }

        public Telefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Telefone não pode ser vazio.");

            var apenasDigitos = new string(numero.Where(char.IsDigit).ToArray());

            if (apenasDigitos.Length != 11)
                throw new ArgumentException("Telefone deve conter 11 dígitos (DDD + número).");

            Numero = apenasDigitos;
        }

        public override string ToString() => Numero;
    }

}
