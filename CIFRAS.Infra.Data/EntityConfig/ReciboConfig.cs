using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ReciboConfig : EntityTypeConfiguration<Recibo>
    {
        public ReciboConfig()
        {
            HasKey(x => x.ReciboId);
            Property(x => x.ReciboId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NomeFantasiaConcedente).IsRequired().HasMaxLength(150);
            Property(x => x.TelefoneConcedente).IsRequired().HasMaxLength(16);
            Property(x => x.CustoTed).IsOptional();
            Property(x => x.OutrosDescontos).IsOptional();
            Property(x => x.Observacoes).IsOptional().HasMaxLength(255); 
            Property(x => x.DataEmissao).IsRequired();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Corretor).WithMany(x => x.ListaRecibo).HasForeignKey(x => x.CorretorId).WillCascadeOnDelete(false);
        }
    }
}