using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ContatoConfig : EntityTypeConfiguration<Contato>
    {
       public ContatoConfig()
        {
            HasKey(x => x.ContatoId);
            Property(x => x.ContatoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            Property(x => x.TipoContato).IsRequired();

            HasRequired(x => x.Cliente).WithMany(x => x.ListaContato).HasForeignKey(x => x.ClienteId).WillCascadeOnDelete(false);
        }
    }
}