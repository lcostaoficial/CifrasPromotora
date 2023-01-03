using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ReciboEmprestimoConfig : EntityTypeConfiguration<ReciboEmprestimo>
    {
        public ReciboEmprestimoConfig()
        {
            HasKey(x => x.ReciboEmprestimoId);
            Property(x => x.ReciboEmprestimoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NomeCliente).IsRequired().HasMaxLength(150);
            Property(x => x.EspecificacaoEmprestimo).IsRequired();
            Property(x => x.ValorSolicitado).IsRequired();
            Property(x => x.ValorLiberado).IsRequired();
            Property(x => x.QtdeParcelas).IsRequired();
            Property(x => x.PercentualComissao).IsRequired();

            HasRequired(x => x.Banco).WithMany(x => x.ListaReciboEmprestimo).HasForeignKey(x => x.BancoId).WillCascadeOnDelete(false);

            HasRequired(x => x.TipoCliente).WithMany(x => x.ListaReciboEmprestimo).HasForeignKey(x => x.TipoClienteId).WillCascadeOnDelete(false);

            HasRequired(x => x.Recibo).WithMany(x => x.ListaReciboEmprestimo).HasForeignKey(x => x.ReciboId).WillCascadeOnDelete(false);
        }
    }
}