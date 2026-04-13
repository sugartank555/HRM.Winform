using Microsoft.Extensions.Configuration;

namespace HRM.Winform.Helpers
{
    public static class AppConfiguration
    {
        private static readonly Lazy<IConfigurationRoot> _configuration = new(() =>
            new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables()
                .Build());

        public static IConfigurationRoot Current => _configuration.Value;

        public static string GetRequiredConnectionString()
        {
            var connectionString =
                Environment.GetEnvironmentVariable("HRM_CONNECTION_STRING")
                ?? Current.GetConnectionString("HRMDb")
                ?? Current["HRMDb:ConnectionString"];

            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                return connectionString;
            }

            throw new InvalidOperationException(
                "Chưa cấu hình chuỗi kết nối CSDL. Hãy khai báo HRM_CONNECTION_STRING hoặc ConnectionStrings:HRMDb trong appsettings.json.");
        }

        public static bool IsDefaultSeedEnabled()
        {
            if (bool.TryParse(Environment.GetEnvironmentVariable("HRM_ENABLE_SEED"), out var enabledFromEnv))
            {
                return enabledFromEnv;
            }

            return Current.GetValue<bool>("SeedData:EnableDefaultSeed");
        }
    }
}
