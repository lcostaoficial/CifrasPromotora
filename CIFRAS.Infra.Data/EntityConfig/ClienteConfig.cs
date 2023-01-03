using CIFRAS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CIFRAS.Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(x => x.ClienteId);
            Property(x => x.ClienteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired().HasMaxLength(150);
            Property(x => x.Cpf).IsRequired().HasMaxLength(14);
            Property(x => x.Rg).IsOptional().HasMaxLength(12);
            Property(x => x.DataExpedicaoRg).IsOptional();
            Property(x => x.OrgaoRg).IsOptional().HasMaxLength(100);
            Property(x => x.Cnh).IsOptional().HasMaxLength(11);
            Property(x => x.DataNascimento).IsOptional();
            Property(x => x.NumeroMatricula).IsRequired().HasMaxLength(20);         
            Property(x => x.OrgaoFuncional).IsOptional().HasMaxLength(100);
            Property(x => x.SituacaoCliente).IsOptional();
            Property(x => x.NumeroEspecie).IsOptional();
            Property(x => x.Sexo).IsOptional();
            Property(x => x.Anotacoes).IsOptional().HasMaxLength(255);
            Property(x => x.RendaBruta).IsOptional();
            Property(x => x.DescontoRenda).IsOptional();            
            Property(x => x.Rmc).IsOptional();
            Property(x => x.UsoRmc).IsOptional();
            Property(x => x.CodigoBancoRmc).IsOptional();
            Property(x => x.DataVisualizacao).IsOptional();
            Property(x => x.Ativo).IsRequired();

            HasRequired(x => x.Endereco).WithMany(x => x.ListaCliente).HasForeignKey(x => x.EnderecoId).WillCascadeOnDelete(false);

            HasRequired(x => x.TipoCliente).WithMany(x => x.ListaCliente).HasForeignKey(x => x.TipoClienteId).WillCascadeOnDelete(false);
        }
    }
}