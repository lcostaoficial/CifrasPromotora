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
    public class ReciboRepository : RepositoryBase<Recibo>, IReciboRepository
    {
        public ReciboRepository(CifrasContext cifrasContext) : base(cifrasContext) { }

        private void BalanciarListaReciboEmprestimo(Recibo model)
        {
            var reciboExistente = Context.Recibos.Where(r => r.ReciboId == model.ReciboId).Include(r => r.ListaReciboEmprestimo).SingleOrDefault();
            if (reciboExistente != null)
            {
                //Atualiza recibo
                Context.Entry(reciboExistente).CurrentValues.SetValues(model);
                //Apaga lista de empréstimo do recibo
                foreach (var reciboEmprestimoExistente in reciboExistente.ListaReciboEmprestimo.ToList())
                {
                    if (!model.ListaReciboEmprestimo.Any(c => c.ReciboEmprestimoId == reciboEmprestimoExistente.ReciboEmprestimoId))
                        Context.RecibosEmprestimos.Remove(reciboEmprestimoExistente);
                }
                //Atualiza e insere lista de empréstimo do recibo
                foreach (var reciboEmprestimoNovo in model.ListaReciboEmprestimo)
                {
                    var reciboEmprestimoExistente = reciboExistente.ListaReciboEmprestimo.Where(r => r.ReciboEmprestimoId == reciboEmprestimoNovo.ReciboEmprestimoId && r.ReciboEmprestimoId != default(int)).SingleOrDefault();
                    if (reciboEmprestimoExistente != null)
                        //Atualiza lista de empréstimo do recibo
                        Context.Entry(reciboEmprestimoExistente).CurrentValues.SetValues(reciboEmprestimoNovo);
                    else
                    {
                        //Insere empréstimo do recibo
                        var reciboEmprestimo = new ReciboEmprestimo
                        {
                            NomeCliente = reciboEmprestimoNovo.NomeCliente,
                            EspecificacaoEmprestimo = reciboEmprestimoNovo.EspecificacaoEmprestimo,
                            ValorSolicitado = reciboEmprestimoNovo.ValorSolicitado,
                            ValorLiberado = reciboEmprestimoNovo.ValorLiberado,
                            QtdeParcelas = reciboEmprestimoNovo.QtdeParcelas,
                            PercentualComissao = reciboEmprestimoNovo.PercentualComissao,
                            BancoId = reciboEmprestimoNovo.BancoId,
                            TipoClienteId = reciboEmprestimoNovo.TipoClienteId
                        };
                        reciboExistente.ListaReciboEmprestimo.Add(reciboEmprestimo);
                    }
                }
            }
        }

        public override Recibo Atualizar(Recibo model)
        {
            BalanciarListaReciboEmprestimo(model);
            Context.SaveChanges();
            return model;
        }

        public int ContarRegistros(bool ativo = true)
        {
            return DbSet.Count(x => x.Ativo == ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Recibo, bool>> expression)
        {
            return DbSet.Count(expression);
        }

        public Recibo BuscarPorId(int id, bool ativo = true)
        {
            return DbSet.FirstOrDefault(x => x.ReciboId == id && x.Ativo == ativo);
        }

        public Recibo BuscarPorIdCustomizado(int id, bool ativo = true)
        {
            return DbSet.Include(x => x.ListaReciboEmprestimo.Select(y => y.Banco)).Include(x => x.ListaReciboEmprestimo.Select(y => y.TipoCliente)).Include(x => x.Corretor.Banco).FirstOrDefault(x => x.ReciboId == id && x.Ativo == ativo);
        }

        public ICollection<Recibo> BuscarPorExpressao(Expression<Func<Recibo, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }          

        public ICollection<Recibo> ObterTodosPaginado(Expression<Func<Recibo, bool>> expression, int start, int take, string orderBy)
        {
            return DbSet.Include(x => x.Corretor).Include(x => x.ListaReciboEmprestimo).Where(expression).OrderBy(orderBy).Skip(start).Take(take).ToList();
        }

        public ICollection<Recibo> BuscarTodos(bool ativo = true)
        {
            return DbSet.Where(x => x.Ativo == ativo).ToList();
        }
    }
}