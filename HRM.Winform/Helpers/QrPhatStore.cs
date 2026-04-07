using System.Text.Json;

namespace HRM.Winform.Helpers
{
    public sealed class QrPhatRecord
    {
        public int NhanVienId { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgayLamViec { get; set; }
        public string TenCa { get; set; } = string.Empty;
        public string MaCa { get; set; } = "FREE";
        public string MaQr { get; set; } = string.Empty;
        public DateTime PhatLuc { get; set; }
        public string NguoiPhat { get; set; } = string.Empty;
    }

    public static class QrPhatStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private static string GetStorePath()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "QrStore");

            Directory.CreateDirectory(root);
            return Path.Combine(root, "qr_phat_records.json");
        }

        public static List<QrPhatRecord> LoadAll()
        {
            string path = GetStorePath();
            if (!File.Exists(path))
            {
                return [];
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<QrPhatRecord>>(json, JsonOptions) ?? [];
        }

        public static void Save(QrPhatRecord record)
        {
            var records = LoadAll();
            records.RemoveAll(x => x.NhanVienId == record.NhanVienId && x.NgayLamViec.Date == record.NgayLamViec.Date);
            records.Add(record);

            string path = GetStorePath();
            string json = JsonSerializer.Serialize(records.OrderByDescending(x => x.NgayLamViec).ThenBy(x => x.NhanVienId).ToList(), JsonOptions);
            File.WriteAllText(path, json);
        }

        public static Dictionary<int, QrPhatRecord> GetLatestByNhanVien()
        {
            return LoadAll()
                .GroupBy(x => x.NhanVienId)
                .ToDictionary(
                    x => x.Key,
                    x => x.OrderByDescending(y => y.PhatLuc).First());
        }
    }
}
