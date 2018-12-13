using ESX.Data.UnitWork;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ESX.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private UnitOfWork _unitOfWork;
        protected ISession Session { get { return _unitOfWork.Session; } }

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public int Count()
        {
            return Session.Query<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> expressao)
        {
            return Session.Query<T>().Where(expressao).Count();
        }

        public bool Any(Expression<Func<T, bool>> expressao)
        {
            return Session.Query<T>().Where(expressao).Any();
        }

        public T Obter(int id)
        {
            return Session.Get<T>(id);
        }

        public T ObterOnde(Expression<Func<T, bool>> expressao)
        {
            return Session.Query<T>().Where(expressao).FirstOrDefault();
        }

        public IEnumerable<T> ObterTodos()
        {
            return Session.Query<T>().ToList();
        }

        public IEnumerable<T> ObterTodosOnde(Expression<Func<T, bool>> expressao)
        {
            return Session.Query<T>().Where(expressao).ToList();
        }

        public IEnumerable<T> ObterPaginado(int paginaAtual, int qtdPorPagina, out int qtdTotalRegistros)
        {
            if (paginaAtual <= 0)
                throw new Exception("paginaAtual não pode ser 0");

            qtdTotalRegistros = this.Count();
            var lst = Session.Query<T>();

            return lst.Skip((paginaAtual - 1) * qtdPorPagina).Take(qtdPorPagina).ToList();
        }

        public IEnumerable<T> ObterPaginadoOnde(Expression<Func<T, bool>> expressao, int paginaAtual, int qtdPorPagina, out int qtdTotalRegistros)
        {
            if (paginaAtual <= 0)
                throw new Exception("paginaAtual não pode ser 0");

            qtdTotalRegistros = this.Count(expressao);
            var lst = Session.Query<T>().Where(expressao);

            return lst.Skip((paginaAtual - 1) * qtdPorPagina).Take(qtdPorPagina).ToList();
        }

        public void Adicionar(T entidade)
        {
            Session.Save(entidade);
            Session.Flush();
        }

        public void Remover(T entidade)
        {
            Session.Delete(entidade);
            Session.Flush();
        }

        public void Alterar(T entidade)
        {
            Session.Update(entidade);
            Session.Flush();
        }
    }
}
