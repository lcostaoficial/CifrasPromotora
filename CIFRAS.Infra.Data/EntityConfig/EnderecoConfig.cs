using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(x => x.EnderecoId);
            Property(x => x.EnderecoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NomeEndereco).IsOptional().HasMaxLength(255);         
            Property(x => x.Bairro).IsOptional().HasMaxLength(100);
            Property(x => x.Cidade).IsOptional().HasMaxLength(100);
            Property(x => x.Estado).IsOptional();
            Property(x => x.Cep).IsOptional().HasMaxLength(8);
        }
    }
}