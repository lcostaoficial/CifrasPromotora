using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class FuncionarioConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioConfig()
        {
            HasKey(x => x.FuncionarioId);
            Property(x => x.FuncionarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired().HasMaxLength(150);
            Property(x => x.Cpf).IsRequired().HasMaxLength(14);
            Property(x => x.Senha).IsRequired().HasMaxLength(8);
            Property(x => x.Cargo).IsRequired();
            Property(x => x.Ativo).IsRequired();
        }
    }
}