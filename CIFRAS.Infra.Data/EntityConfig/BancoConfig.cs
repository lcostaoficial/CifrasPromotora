using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class BancoConfig : EntityTypeConfiguration<Banco>
    {
        public BancoConfig()
        {
            HasKey(x => x.BancoId);
            Property(x => x.BancoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            Property(x => x.Sigla).IsOptional().HasMaxLength(10);
            Property(x => x.CodigoBanco).IsOptional();
            Property(x => x.Ativo).IsRequired();
        }
    }
}