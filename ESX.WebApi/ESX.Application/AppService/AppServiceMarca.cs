using ESX.Application.Interfaces;
using ESX.Domain.Entities;
using ESX.Domain.Exceptions;
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
            if (ValidarCategoriaExistente(Nome, id))
                throw new CategoriaJaCadastradaException();

            var obj = this.Obter(id);

            if (obj == null)
                throw new MarcaNaoEncontradaException();

            obj.Nome = Nome;

            this.Alterar(obj);
        }

        public void Cadastrar(string Nome)
        {
            if (ValidarCategoriaExistente(Nome))
                throw new CategoriaJaCadastradaException();

            var obj = new Marca();
            obj.Nome = Nome;

            this.Adicionar(obj);
        }

        private bool ValidarCategoriaExistente(string Nome, int? Id = null)
        {
            return this.Any(x => x.Nome == Nome && (!Id.HasValue || x.Id != Id));
        }
    }
}
