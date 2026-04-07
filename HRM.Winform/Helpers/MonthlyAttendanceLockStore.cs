using System.Text.Json;

namespace HRM.Winform.Helpers
{
    public sealed class MonthlyAttendanceLockRecord
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public bool IsLocked { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }

    public static class MonthlyAttendanceLockStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        private static string DirectoryPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HRM.Winform", "AttendanceLocks");

        private static string FilePath => Path.Combine(DirectoryPath, "monthly_locks.json");

        public static List<MonthlyAttendanceLockRecord> LoadAll()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return [];
                }

                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<MonthlyAttendanceLockRecord>>(json, JsonOptions) ?? [];
            }
            catch
            {
                return [];
            }
        }

        public static MonthlyAttendanceLockRecord? Get(int month, int year)
        {
            return LoadAll()
                .FirstOrDefault(x => x.Month == month && x.Year == year);
        }

        public static bool IsLocked(DateTime date)
        {
            return Get(date.Month, date.Year)?.IsLocked == true;
        }

        public static void Save(MonthlyAttendanceLockRecord record)
        {
            Directory.CreateDirectory(DirectoryPath);
            var items = LoadAll();
            var existing = items.FirstOrDefault(x => x.Month == record.Month && x.Year == record.Year);

            if (existing == null)
            {
                items.Add(record);
            }
            else
            {
                existing.IsLocked = record.IsLocked;
                existing.UpdatedAt = record.UpdatedAt;
                existing.UpdatedBy = record.UpdatedBy;
                existing.Note = record.Note;
            }

            items = items.OrderByDescending(x => x.Year).ThenByDescending(x => x.Month).ToList();
            File.WriteAllText(FilePath, JsonSerializer.Serialize(items, JsonOptions));
        }
    }
}
