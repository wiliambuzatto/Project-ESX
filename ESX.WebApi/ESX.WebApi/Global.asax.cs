using ESX.WebApi.Mappers;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ESX.WebApi
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AutoMapperConfig.RegisterMappings();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.None,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };
        }
    }
}