using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Northwind.Infrastructure.Registries
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.AssembliesFromApplicationBaseDirectory(
                    a => a.FullName.StartsWith("Northwind")); // Needed if Registries are in different project than website
                scan.WithDefaultConventions();
            });
        }
    }
}