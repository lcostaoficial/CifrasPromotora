using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class TipoContratoConfig : EntityTypeConfiguration<TipoContrato>
    {
        public TipoContratoConfig()
        {
            HasKey(x => x.TipoContratoId);
            Property(x => x.TipoContratoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            Property(x => x.Ativo).IsRequired();
        }
    }
}
