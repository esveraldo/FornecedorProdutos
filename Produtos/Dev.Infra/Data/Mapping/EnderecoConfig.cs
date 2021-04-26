using Dev.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Infra.Data.Mapping
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e=>e.Id);

            Property(e => e.Logradouro).IsRequired().HasMaxLength(200);
            Property(e => e.Numero).IsRequired().HasMaxLength(10);
            Property(e => e.Complemento).IsRequired().HasMaxLength(50);
            Property(e => e.Cep).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(e => e.Bairro).IsRequired().HasMaxLength(200);
            Property(e => e.Cidade).IsRequired().HasMaxLength(200);
            Property(e => e.Estado).IsRequired().HasMaxLength(200);

            ToTable("Enderecos");
        }
    }
}
