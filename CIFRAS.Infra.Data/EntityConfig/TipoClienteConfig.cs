using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class TipoClienteConfig : EntityTypeConfiguration<TipoCliente>
    {
        public TipoClienteConfig()
        {
            HasKey(x => x.TipoClienteId);
            Property(x => x.TipoClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            Property(x => x.Ativo).IsRequired();
        }
    }
}