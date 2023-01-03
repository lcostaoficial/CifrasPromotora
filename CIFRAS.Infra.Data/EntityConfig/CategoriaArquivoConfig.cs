using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class CategoriaArquivoConfig : EntityTypeConfiguration<CategoriaArquivo>
    {
        public CategoriaArquivoConfig()
        {
            HasKey(x => x.CategoriaArquivoId);
            Property(x => x.CategoriaArquivoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Descricao).IsRequired().HasMaxLength(255);
            Property(x => x.Ativo).IsRequired();
        }
    }
}