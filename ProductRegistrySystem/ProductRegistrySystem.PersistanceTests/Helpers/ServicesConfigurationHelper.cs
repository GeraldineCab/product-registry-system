using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace ProductRegistrySystem.PersistenceTests.Helpers
{
    public static class ServicesConfigurationHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot()
        {
            return new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile("vaultsettings.json")
                .Build();
        }
    }
}
