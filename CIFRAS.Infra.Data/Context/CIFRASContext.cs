using CIFRAS.Domain.Entities;
using CIFRAS.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;

namespace CIFRAS.Infra.Data.Context
{
    public class CifrasContext : DbContext 
    {
        public CifrasContext()
            : base("DBCIFRAS") { }
      
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<CategoriaArquivo> CategoriasArquivos { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<TipoContrato> TiposContratos { get; set; }
        public DbSet<TipoCliente> TiposClientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Recibo> Recibos { get; set; }
        public DbSet<ReciboEmprestimo> RecibosEmprestimos { get; set; }
        public DbSet<Corretor> Corretores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {        
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();          

            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(x => x.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new CategoriaArquivoConfig());
            modelBuilder.Configurations.Add(new ArquivoConfig());
            modelBuilder.Configurations.Add(new BancoConfig());
            modelBuilder.Configurations.Add(new ContaConfig());
            modelBuilder.Configurations.Add(new ContatoConfig());
            modelBuilder.Configurations.Add(new ContratoConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new TipoContratoConfig());
            modelBuilder.Configurations.Add(new TipoClienteConfig());
            modelBuilder.Configurations.Add(new FuncionarioConfig());
            modelBuilder.Configurations.Add(new ReciboConfig());
            modelBuilder.Configurations.Add(new ReciboEmprestimoConfig());
            modelBuilder.Configurations.Add(new CorretorConfig());
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.Entries)
                {
                    sb.Append($"ERROS:\n{failure.State}\n{failure.Entity.GetType().Name}");
                }
                var erro = sb.ToString();
                throw;
            }
            catch (DbUnexpectedValidationException un)
            {
                var erro = un.Message;
                throw;
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                var erro = ex.Message;
                throw;
            }
        }
    }
}