using Microsoft.EntityFrameworkCore;
using PedidoService.Domain.Entities;
using PedidoService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>
    {
        public ClienteRepository(PedidoDbContext context) : base(context) { }

        public async Task<Cliente?> BuscarPorCpfAsync(string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<bool> ExisteEmailAsync(string email)
        {
            return await _dbSet.AnyAsync(c => c.Email.Endereco == email);
        }

    }
}
