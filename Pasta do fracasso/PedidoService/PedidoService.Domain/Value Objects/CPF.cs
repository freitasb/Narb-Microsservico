using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Domain.Value_Objects
{
    public record CPF
    {
        public string Numero { get; }

        public CPF(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("CPF é obrigatório.");

            var apenasDigitos = new string(numero.Where(char.IsDigit).ToArray());

            if (apenasDigitos.Length != 11)
                throw new ArgumentException("CPF deve ter 11 dígitos.");

            // (Aqui você pode colocar a lógica de validação de CPF real, se quiser)

            Numero = apenasDigitos;
        }

        public override string ToString() => Numero;

        public override int GetHashCode() => Numero.GetHashCode();
    }
}
