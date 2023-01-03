using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ContaConfig : EntityTypeConfiguration<Conta>
    {
        public ContaConfig()
        {
            HasKey(x => x.ContaId);
            Property(x => x.ContaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NumeroAgencia).IsRequired().HasMaxLength(10);
            Property(x => x.NumeroConta).IsRequired().HasMaxLength(10);

            HasRequired(x => x.Cliente).WithMany(x => x.ListaConta).HasForeignKey(x => x.ClienteId).WillCascadeOnDelete(false);

            HasOptional(x => x.Banco).WithMany(x => x.ListaConta).HasForeignKey(x => x.BancoId).WillCascadeOnDelete(false);
        }
    }
}