using CommonServiceLocator.NinjectAdapter.Unofficial;
using ESX.CrossCutting.NinjectCommon.Modules;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace ESX.CrossCutting.NinjectCommon
{
    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ApplicationNinjectModule(),
                new InfrastructureNinjectModule(),
                new RepositoryNinjectModule(),
                new ServiceNinjectModule()
                );
        }
    }
}
