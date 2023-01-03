using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class CorretorConfig : EntityTypeConfiguration<Corretor>
    {
        public CorretorConfig()
        {
            HasKey(x => x.CorretorId);
            Property(x => x.CorretorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired().HasMaxLength(150);
            Property(x => x.NomeAbreviado).IsRequired().HasMaxLength(20);
            Property(x => x.Cpf).IsRequired().HasMaxLength(14);
            Property(x => x.NumeroAgencia).IsRequired().HasMaxLength(10);
            Property(x => x.NumeroConta).IsRequired().HasMaxLength(10);
            Property(x => x.TipoConta).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Banco).WithMany(x => x.ListaCorretor).HasForeignKey(x => x.BancoId).WillCascadeOnDelete(false);
        }
    }
}