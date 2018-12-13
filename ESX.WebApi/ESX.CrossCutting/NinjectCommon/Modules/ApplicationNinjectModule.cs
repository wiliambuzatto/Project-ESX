using ESX.Application.AppService;
using ESX.Application.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.CrossCutting.NinjectCommon.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppServiceBase<>)).To((typeof(AppServiceBase<>)));
            Bind<IAppServiceMarca>().To<AppServiceMarca>();
            Bind<IAppServicePatrimonio>().To<AppServicePatrimonio>();
        }
    }
}
