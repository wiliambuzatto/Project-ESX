using ESX.Application.Interfaces;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ESX.Application.AppService
{
    public abstract class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private IUnitOfWork _unitOfWork;
        private IRepositoryBase<T> _repositoryBase;

        public AppServiceBase(IUnitOfWork unitOfWork, IRepositoryBase<T> repositoryBase)
        {
            _unitOfWork = unitOfWork;
            _repositoryBase = repositoryBase;
        }

        protected void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        protected void Commit()
        {
            _unitOfWork.Commit();
        }

        protected void Rollback()
        {
            _unitOfWork.Rollback();
        }

        public virtual void Adicionar(T entidade)
        {
            _repositoryBase.Adicionar(entidade);
        }

        public virtual void Alterar(T entidade)
        {
            _repositoryBase.Alterar(entidade);
        }

        public virtual bool Any(Expression<Func<T, bool>> expressao)
        {
            return _repositoryBase.Any(expressao);
        }

        public virtual int Count()
        {
            return _repositoryBase.Count();
        }

        public virtual int Count(Expression<Func<T, bool>> expressao)
        {
            return _repositoryBase.Count(expressao);
        }

        public virtual T Obter(int id)
        {
            return _repositoryBase.Obter(id);
        }

        public virtual T ObterOnde(Expression<Func<T, bool>> expressao)
        {
            return _repositoryBase.ObterOnde(expressao);
        }

        public virtual IEnumerable<T> ObterPaginado(int paginaAtual, int qtdPorPagina, out int qtdTotalRegistros)
        {
            return _repositoryBase.ObterPaginado(paginaAtual, qtdPorPagina, out qtdTotalRegistros);
        }

        public virtual IEnumerable<T> ObterPaginadoOnde(Expression<Func<T, bool>> expressao, int paginaAtual, int qtdPorPagina, out int qtdTotalRegistros)
        {
            return _repositoryBase.ObterPaginadoOnde(expressao, paginaAtual, qtdPorPagina, out qtdTotalRegistros);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            return _repositoryBase.ObterTodos();
        }

        public virtual IEnumerable<T> ObterTodosOnde(Expression<Func<T, bool>> expressao)
        {
            return _repositoryBase.ObterTodosOnde(expressao);
        }

        public virtual void Remover(T entidade)
        {
            _repositoryBase.Remover(entidade);
        }

        public virtual void Remover(int id)
        {
            var entidade = this.Obter(id);
            _repositoryBase.Remover(entidade);
        }
    }
}
