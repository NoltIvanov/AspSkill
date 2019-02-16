using Microsoft.Extensions.Configuration;

namespace AspLearn.Common.Heloers {
    public static class ConfigurationManager {

        public static string LocalAspLearnDb { get; private set; }

        public static void SetAppSettingsProperties(IConfiguration configuration) {
            LocalAspLearnDb = configuration.GetConnectionString(ConnectionStringNames.LOCAL_APP);
        }
    }
}
