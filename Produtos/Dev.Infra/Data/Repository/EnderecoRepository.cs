using Dev.Business.Models.Fornecedores;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid id)
        {
            return await Db.Enderecos.AsNoTracking().Include(e => e.Fornecedor).FirstOrDefaultAsync(e=>e.Id == id);
        }
    }
}
