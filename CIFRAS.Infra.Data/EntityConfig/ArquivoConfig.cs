using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ArquivoConfig : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoConfig()
        {
            HasKey(x => x.ArquivoId);
            Property(x => x.ArquivoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            Property(x => x.Caminho).IsRequired().HasMaxLength(255);

            HasRequired(x => x.Cliente).WithMany(a => a.ListaArquivo).HasForeignKey(a => a.ClienteId).WillCascadeOnDelete(false);

            HasRequired(x => x.CategoriaArquivo).WithMany(x => x.ListaArquivo).HasForeignKey(x => x.CategoriaArquivoId).WillCascadeOnDelete(false); ;           
        }
    }
}