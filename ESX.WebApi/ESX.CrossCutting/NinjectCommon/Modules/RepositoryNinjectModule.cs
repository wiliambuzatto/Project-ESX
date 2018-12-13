using ESX.Data.Repository;
using ESX.Domain.Interfaces.Repository;
using Ninject.Modules;

namespace ESX.CrossCutting.NinjectCommon.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositoryBase<>)).To((typeof(RepositoryBase<>)));
            Bind<IRepositoryMarca>().To<RepositoryMarca>();
            Bind<IRepositoryPatrimonio>().To<RepositoryPatrimonio>();
        }
    }
}
