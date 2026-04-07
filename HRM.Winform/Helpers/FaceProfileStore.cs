using System.Text.Json;
using System.Drawing;

namespace HRM.Winform.Helpers
{
    public sealed class FaceProfile
    {
        public int NhanVienId { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public DateTime CapturedAt { get; set; }
        public float[] Descriptor { get; set; } = Array.Empty<float>();
        public string ImageDataUrl { get; set; } = string.Empty;
    }

    public static class FaceProfileStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        public static string GetProfileDirectory()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "FaceProfiles");

            Directory.CreateDirectory(root);
            return root;
        }

        public static string GetProfilePath(int nhanVienId)
        {
            return Path.Combine(GetProfileDirectory(), $"nv_{nhanVienId}.json");
        }

        public static bool Exists(int nhanVienId)
        {
            return File.Exists(GetProfilePath(nhanVienId));
        }

        public static bool HasValidProfile(int nhanVienId)
        {
            var profile = Load(nhanVienId);
            return profile != null
                && profile.Descriptor.Length > 0
                && !string.IsNullOrWhiteSpace(profile.ImageDataUrl);
        }

        public static FaceProfile? Load(int nhanVienId)
        {
            string path = GetProfilePath(nhanVienId);
            if (!File.Exists(path))
            {
                return null;
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<FaceProfile>(json, JsonOptions);
        }

        public static void Save(FaceProfile profile)
        {
            string path = GetProfilePath(profile.NhanVienId);
            string json = JsonSerializer.Serialize(profile, JsonOptions);
            File.WriteAllText(path, json);
        }

        public static double ComputeDistance(float[] a, float[] b)
        {
            if (a.Length == 0 || b.Length == 0 || a.Length != b.Length)
            {
                return double.MaxValue;
            }

            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                double diff = a[i] - b[i];
                sum += diff * diff;
            }

            return Math.Sqrt(sum);
        }

        public static Image? CreatePreviewImage(string? imageDataUrl)
        {
            if (string.IsNullOrWhiteSpace(imageDataUrl))
            {
                return null;
            }

            int commaIndex = imageDataUrl.IndexOf(',');
            if (commaIndex < 0 || commaIndex == imageDataUrl.Length - 1)
            {
                return null;
            }

            string base64 = imageDataUrl[(commaIndex + 1)..];
            byte[] bytes = Convert.FromBase64String(base64);
            using var ms = new MemoryStream(bytes);
            using var original = Image.FromStream(ms);
            return new Bitmap(original);
        }
    }
}
