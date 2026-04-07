using System.Text.Json;

namespace HRM.Winform.Helpers
{
    public sealed class OfficeGpsConfig
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AllowedRadiusMeters { get; set; } = 150;
        public DateTime UpdatedAt { get; set; }
    }

    public sealed class GpsCaptureResult
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AccuracyMeters { get; set; }
    }

    public static class GpsCheckInStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        public static string GetConfigPath()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "GpsConfig");

            Directory.CreateDirectory(root);
            return Path.Combine(root, "office_gps.json");
        }

        public static OfficeGpsConfig? LoadOfficeConfig()
        {
            string path = GetConfigPath();
            if (!File.Exists(path))
            {
                return null;
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<OfficeGpsConfig>(json, JsonOptions);
        }

        public static void SaveOfficeConfig(OfficeGpsConfig config)
        {
            config.UpdatedAt = DateTime.Now;
            string path = GetConfigPath();
            string json = JsonSerializer.Serialize(config, JsonOptions);
            File.WriteAllText(path, json);
        }

        public static double ComputeDistanceMeters(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            const double earthRadius = 6371000;
            double dLat = DegreesToRadians(latitude2 - latitude1);
            double dLon = DegreesToRadians(longitude2 - longitude1);

            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(latitude1)) * Math.Cos(DegreesToRadians(latitude2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return earthRadius * c;
        }

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180d;
        }
    }
}
