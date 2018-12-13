using ESX.Domain.Entities;

namespace ESX.Application.Interfaces
{
    public interface IAppServiceMarca : IAppServiceBase<Marca>
    {
        void Cadastrar(string Nome);
        void Alterar(int id, string Nome);
    }
}
