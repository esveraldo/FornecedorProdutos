using Dev.Business.Core.Models;
using Dev.Business.Models.Enums;
using Dev.Business.Models.Fornecedores.Validations;
using Dev.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Business.Models.Fornecedores
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public ICollection<Produto> Produtos { get; set; }

        /*public bool Validacao()
        {
            var validacao = new FornecedorValidation();
            var resultado = validacao.Validate(this);

            return resultado.IsValid;
        }*/
    }
}
