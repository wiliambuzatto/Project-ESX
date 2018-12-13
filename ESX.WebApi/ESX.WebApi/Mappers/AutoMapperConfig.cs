using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace ESX.WebApi.Mappers
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.GetConfiguration();
            });
        }

        private static void GetConfiguration(this IMapperConfigurationExpression configuration)
        {
            var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(Profile)));
            foreach (var profile in profiles)
            {
                configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
            }
        }
    }
}