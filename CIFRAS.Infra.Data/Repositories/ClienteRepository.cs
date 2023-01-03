using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace CIFRAS.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        private void BalanciarListaConta(Cliente model)
        {
            var clienteExistente = Context.Clientes.Where(c => c.ClienteId == model.ClienteId).Include(c => c.ListaConta).SingleOrDefault();
            if (clienteExistente != null)
            {
                //Atualiza cliente
                Context.Entry(clienteExistente).CurrentValues.SetValues(model);
                //Apaga contas
                foreach (var contaExistente in clienteExistente.ListaConta.ToList())
                {
                    if (!model.ListaConta.Any(c => c.ContaId == contaExistente.ContaId))
                        Context.Contas.Remove(contaExistente);
                }
                //Atualiza e insere contas
                foreach (var contaNova in model.ListaConta)
                {
                    var contaExistente = clienteExistente.ListaConta.Where(c => c.ContaId == contaNova.ContaId && c.ContaId != default(int)).SingleOrDefault();
                    if (contaExistente != null)
                        //Atualiza conta
                        Context.Entry(contaExistente).CurrentValues.SetValues(contaNova);
                    else
                    {
                        //Insere conta
                        var conta = new Conta
                        {
                            NumeroAgencia = contaNova.NumeroAgencia,
                            NumeroConta = contaNova.NumeroConta,
                            BancoId = contaNova.BancoId
                        };
                        clienteExistente.ListaConta.Add(conta);
                    }
                }
            }
        }

        private void BalanciarListaContrato(Cliente model)
        {
            var clienteExistente = Context.Clientes.Where(c => c.ClienteId == model.ClienteId).Include(c => c.ListaContrato).SingleOrDefault();
            if (clienteExistente != null)
            {
                //Atualiza cliente
                Context.Entry(clienteExistente).CurrentValues.SetValues(model);
                //Apaga contratos
                foreach (var contratoExistente in clienteExistente.ListaContrato.ToList())
                {
                    if (!model.ListaContrato.Any(c => c.ContratoId == contratoExistente.ContratoId))
                        Context.Contratos.Remove(contratoExistente);
                }
                //Atualiza e insere contratos
                foreach (var contratoNovo in model.ListaContrato)
                {
                    var contratoExistente = clienteExistente.ListaContrato.Where(c => c.ContratoId == contratoNovo.ContratoId && c.ContratoId != default(int)).SingleOrDefault();
                    if (contratoExistente != null)
                        //Atualiza contrato
                        Context.Entry(contratoExistente).CurrentValues.SetValues(contratoNovo);
                    else
                    {
                        //Insere contrato
                        var contrato = new Contrato
                        {
                            TipoContratoId = contratoNovo.TipoContratoId,
                            NumeroContrato = contratoNovo.NumeroContrato,
                            DataInicio = contratoNovo.DataInicio,
                            ValorFinanciado = contratoNovo.ValorFinanciado,
                            ValorParcela = contratoNovo.ValorParcela,
                            TotalParcelas = contratoNovo.TotalParcelas,
                            BancoId = contratoNovo.BancoId
                        };
                        clienteExistente.ListaContrato.Add(contrato);
                    }
                }
            }
        }

        private void BalanciarListaContato(Cliente model)
        {
            var clienteExistente = Context.Clientes.Where(c => c.ClienteId == model.ClienteId).Include(c => c.ListaContato).SingleOrDefault();
            if (clienteExistente != null)
            {
                //Atualiza cliente
                Context.Entry(clienteExistente).CurrentValues.SetValues(model);
                //Apaga contatos
                foreach (var contatoExistente in clienteExistente.ListaContato.ToList())
                {
                    if (!model.ListaContato.Any(c => c.ContatoId == contatoExistente.ContatoId))
                        Context.Contatos.Remove(contatoExistente);
                }
                //Atualiza e insere contatos
                foreach (var contatoNovo in model.ListaContato)
                {
                    var contatoExistente = clienteExistente.ListaContato.Where(c => c.ContatoId == contatoNovo.ContatoId && c.ContatoId != default(int)).SingleOrDefault();
                    if (contatoExistente != null)
                        //Atualiza contato
                        Context.Entry(contatoExistente).CurrentValues.SetValues(contatoNovo);
                    else
                    {
                        //Insere contato
                        var contato = new Contato
                        {
                            Descricao = contatoNovo.Descricao,
                            TipoContato = contatoNovo.TipoContato
                        };
                        clienteExistente.ListaContato.Add(contato);
                    }
                }
            }
        }

        public override Cliente Atualizar(Cliente model)
        {
            BalanciarListaConta(model);
            BalanciarListaContrato(model);
            BalanciarListaContato(model);
            if (model.Endereco != null) Context.Entry(model.Endereco).State = EntityState.Modified;
            Context.SaveChanges();
            return model;
        }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Cliente, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public Cliente ObterPorIdBasico(int id)
        {
            return DbSet.Include(x => x.ListaArquivo).Include(x => x.ListaConta).Include(x => x.ListaContato).Include(x => x.ListaContrato).FirstOrDefault(x => x.ClienteId == id);
        }

        public Cliente BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.Include(x => x.Endereco).Include(x => x.ListaConta).FirstOrDefault(x => x.ClienteId == id && x.Ativo == ativo);
        }

        public Cliente BuscarPorIdCustomizado(int id, bool ativo = true)
        {
            return DbSet.Include(x => x.Endereco).Include(x => x.ListaConta.Select(y => y.Banco)).Include(x => x.ListaContrato.Select(y => y.Banco)).Include(x => x.ListaContrato.Select(y => y.TipoContrato)).Include(x => x.ListaContato).FirstOrDefault(x => x.ClienteId == id && x.Ativo == ativo);
        }

        public ICollection<Cliente> BuscarPorExpressao(Expression<Func<Cliente, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public ICollection<Cliente> ObterTodosPaginado(Expression<Func<Cliente, bool>> expression, int start, int take)
        {
            return DbSet.Include(x => x.ListaContrato).Include(x => x.TipoCliente).Where(expression).OrderBy(x => x.ClienteId).Skip(start).Take(take).ToList();
        }

        public ICollection<Cliente> ObterTodosPaginado(Expression<Func<Cliente, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Include(x => x.ListaContrato).Include(x => x.TipoCliente).Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<Cliente> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }

        public Cliente BuscarPorCpf(string cpf, bool ativo = true)
        {
            return DbSet.Include(x => x.Endereco).Include(x => x.ListaContrato).Include(x => x.ListaContato).Include(x => x.ListaConta).Include(x => x.ListaArquivo).FirstOrDefault(x => (x.Cpf.Replace(".", "").Replace("-", "") == cpf.Replace(".", "").Replace("-", "")) && x.Ativo == ativo);
        }

        public Cliente BuscarPorMatricula(string matricula, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.NumeroMatricula == matricula && x.Ativo == ativo);
        }

        public Cliente BuscarPorCpfEMatricula(string cpf, string matricula, bool ativo = true)
        {
            return DbSet.Include(x => x.Endereco).Include(x => x.ListaContrato).Include(x => x.ListaContato).Include(x => x.ListaConta).Include(x => x.ListaArquivo).FirstOrDefault(x => (x.Cpf.Replace(".", "").Replace("-", "") == cpf.Replace(".", "").Replace("-", "") && x.NumeroMatricula == matricula) && x.Ativo == ativo);
        }

        public bool PermitirInserir(string cpf, string matricula, bool ativo = true)
        {
            return DbSet.Any(x => (x.Cpf.Replace(".", "").Replace("-", "") == cpf.Replace(".", "").Replace("-", "") && x.NumeroMatricula.ToLower() != matricula.ToLower()) && x.Ativo == ativo);
        }
    }
}