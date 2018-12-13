using ESX.Domain.Entities;

namespace ESX.Application.Interfaces
{
    public interface IAppServicePatrimonio : IAppServiceBase<Patrimonio>
    {
        void Cadastrar(string Nome, string Descricao, int IdMarca);
        void Alterar(int id, string Nome, string Descricao, int IdMarca);
    }
}
