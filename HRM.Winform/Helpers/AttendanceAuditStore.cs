using System.Text.Json;

namespace HRM.Winform.Helpers
{
    public sealed class AttendanceAuditEntry
    {
        public int NhanVienId { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime ThoiGian { get; set; }
        public string HanhDong { get; set; } = string.Empty;
        public string PhuongThuc { get; set; } = string.Empty;
        public string KetQua { get; set; } = string.Empty;
        public string ChiTiet { get; set; } = string.Empty;
    }

    public static class AttendanceAuditStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        private static string DirectoryPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HRM.Winform", "AuditLogs");

        private static string FilePath => Path.Combine(DirectoryPath, "attendance_audit.json");

        public static List<AttendanceAuditEntry> LoadAll()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return [];
                }

                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<AttendanceAuditEntry>>(json, JsonOptions) ?? [];
            }
            catch
            {
                return [];
            }
        }

        public static void Save(AttendanceAuditEntry entry)
        {
            Directory.CreateDirectory(DirectoryPath);
            var items = LoadAll();
            items.Add(entry);

            items = items
                .OrderByDescending(x => x.ThoiGian)
                .Take(2000)
                .ToList();

            File.WriteAllText(FilePath, JsonSerializer.Serialize(items, JsonOptions));
        }
    }
}
