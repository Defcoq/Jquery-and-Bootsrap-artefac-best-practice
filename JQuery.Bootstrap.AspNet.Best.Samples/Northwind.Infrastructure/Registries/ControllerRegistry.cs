
using Northwind.Infrastructure.Conventions;
using StructureMap.Configuration.DSL;

namespace Northwind.Infrastructure.Registries
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AssembliesFromApplicationBaseDirectory(
                    a => a.FullName.StartsWith("Northwind")); // Needed if Registries are in different project than website
                scan.With(new ControllerConvention());
            });
        }
    }
}
