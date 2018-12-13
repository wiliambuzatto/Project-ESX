using ESX.Application.Interfaces;
using ESX.Domain.Entities;
using ESX.Domain.Interfaces.Repository;
using ESX.Domain.Interfaces.UnitWork;
namespace ESX.Application.AppService
{
    public class AppServiceMarca : AppServiceBase<Marca>, IAppServiceMarca
    {
        public AppServiceMarca(IUnitOfWork unitOfWork, IRepositoryBase<Marca> repositoryBase)
               : base(unitOfWork, repositoryBase)
        {
        }

        public void Alterar(int id, string Nome)
        {
            var obj = this.Obter(id);
            obj.Nome = Nome;

            this.Alterar(obj);
        }

        public void Cadastrar(string Nome)
        {
            var obj = new Marca();
            obj.Nome = Nome;

            this.Adicionar(obj);
        }
    }
}
