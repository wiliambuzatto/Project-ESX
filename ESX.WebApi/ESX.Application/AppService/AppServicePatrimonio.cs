using ESX.Application.Interfaces;
using ESX.Domain.Entities;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;

namespace ESX.Application.AppService
{
    public class AppServicePatrimonio : AppServiceBase<Patrimonio>, IAppServicePatrimonio
    {
        private readonly IAppServiceMarca _appServiceMarca;
        public AppServicePatrimonio(IUnitOfWork unitOfWork, IRepositoryBase<Patrimonio> repositoryBase,
            IAppServiceMarca appServiceMarca)
               : base(unitOfWork, repositoryBase)
        {
            _appServiceMarca = appServiceMarca;
        }

        public void Alterar(int id, string Nome, string Descricao, int IdMarca)
        {
            var obj = this.Obter(id);
            var objMarca = _appServiceMarca.Obter(IdMarca);
            obj.Nome = Nome;
            obj.Descricao = Descricao;
            obj.Marca = objMarca;

            this.Adicionar(obj);
        }

        public void Cadastrar(string Nome, string Descricao, int IdMarca)
        {
            var obj = new Patrimonio();
            var objMarca = _appServiceMarca.Obter(IdMarca);
            obj.Nome = Nome;
            obj.Descricao = Descricao;
            obj.Marca = objMarca;
            obj.CriarNumeroTombo();

            this.Adicionar(obj);

        }
    }
}
