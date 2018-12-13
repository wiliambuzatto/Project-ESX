using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Reflection;


namespace ESX.Data.NHibernate
{
    public static class FluentExtensions
    {
        public static FluentMappingsContainer AddFromAssembliesInPath(this FluentMappingsContainer container)
        {
            var path = AppDomain.CurrentDomain.RelativeSearchPath;

            if (string.IsNullOrWhiteSpace(path))
                path = AppDomain.CurrentDomain.BaseDirectory;

            var assemblies =
                Directory
                    .EnumerateFiles(path, "*.dll", SearchOption.AllDirectories)
                    .Where(filename => Path.GetFileName(filename).ToLowerInvariant().Contains("esx.data"))
                    .Select(Assembly.LoadFile);

            foreach (var assembly in assemblies)
                container.AddFromAssembly(assembly).AddConventions();

            return container;
        }

        public static FluentMappingsContainer AddConventions(this FluentMappingsContainer container)
        {
            container.Conventions.Add(ConventionBuilder.Property.When(
                                      c => c.Expect(x => x.Property.PropertyType == typeof(string)),
                                      x => x.CustomType("AnsiString")));

            container.Conventions.Add(ConventionBuilder.Property.When(
                                  c => c.Expect(x => x.Property.PropertyType == typeof(decimal)),
                                  x => x.Scale(2)));

            container.Conventions.Add(ConventionBuilder.Property.When(
                                  c => c.Expect(x => x.Property.PropertyType == typeof(decimal)),
                                  x => x.Precision(18)));

            return container;
        }
    }
}
