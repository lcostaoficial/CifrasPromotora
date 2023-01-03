using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ContratoConfig : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfig()
        {
            HasKey(x => x.ContratoId);
            Property(x => x.ContratoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.NumeroContrato).IsRequired();
            Property(x => x.DataInicio).IsOptional();          
            Property(x => x.ValorFinanciado).IsRequired();           
            Property(x => x.ValorParcela).IsRequired();
            Property(x => x.TotalParcelas).IsRequired();           

            HasRequired(x => x.Cliente).WithMany(x => x.ListaContrato).HasForeignKey(x => x.ClienteId).WillCascadeOnDelete(false);

            HasOptional(x => x.Banco).WithMany(x => x.ListaContrato).HasForeignKey(x => x.BancoId).WillCascadeOnDelete(false);

            HasRequired(x => x.TipoContrato).WithMany(x => x.ListaContrato).HasForeignKey(x => x.TipoContratoId).WillCascadeOnDelete(false);
        }
    }
}