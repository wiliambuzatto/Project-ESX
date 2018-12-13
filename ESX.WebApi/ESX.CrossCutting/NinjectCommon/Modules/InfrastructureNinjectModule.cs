using ESX.Data.UnitWork;
using ESX.Domain.Interfaces.UnitWork;
using Ninject.Modules;

namespace ESX.CrossCutting.NinjectCommon.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
