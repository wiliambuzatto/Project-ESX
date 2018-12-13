using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace ESX.Application.Interfaces
{
    public interface IAppServiceBase<T> where T : class
    {
        int Count();
        int Count(Expression<Func<T, bool>> expressao);
        bool Any(Expression<Func<T, bool>> expressao);
        T Obter(int id);
        T ObterOnde(Expression<Func<T, bool>> expressao);
        IEnumerable<T> ObterTodos();
        IEnumerable<T> ObterTodosOnde(Expression<Func<T, bool>> expressao);
        IEnumerable<T> ObterPaginado(int paginaAtual, int qtdPorPagina, out int qtdTotalRegistros);
        IEnumerable<T> ObterPaginadoOnde(Expression<Func<T, bool>> expressao, int paginaAtual, int qtdPorPagina, out int qtdTotalRegistros);
        void Adicionar(T entidade);
        void Remover(T entidade);
        void Remover(int id);
        void Alterar(T entidade);
    }
}
