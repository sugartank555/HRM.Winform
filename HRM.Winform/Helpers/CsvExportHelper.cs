using System.Text;
using System.Reflection;

namespace HRM.Winform.Helpers
{
    public static class CsvExportHelper
    {
        public static void Export<T>(IReadOnlyCollection<T> items, string defaultFileName, IDictionary<string, string>? headers = null)
        {
            if (items.Count == 0)
            {
                MessageBox.Show("Khong co du lieu de xuat.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "CSV UTF-8 (*.csv)|*.csv",
                FileName = defaultFileName,
                Title = "Xuat du lieu Excel-friendly"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanRead)
                .ToArray();

            var sb = new StringBuilder();
            sb.AppendLine(string.Join(",", properties.Select(p => Escape(headers != null && headers.TryGetValue(p.Name, out var header) ? header : p.Name))));

            foreach (var item in items)
            {
                sb.AppendLine(string.Join(",", properties.Select(p => Escape(FormatValue(p.GetValue(item))))));
            }

            File.WriteAllText(dialog.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Da xuat file thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string FormatValue(object? value)
        {
            return value switch
            {
                null => string.Empty,
                DateTime dt => dt.ToString("dd/MM/yyyy HH:mm:ss"),
                DateOnly d => d.ToString("dd/MM/yyyy"),
                bool b => b ? "Co" : "Khong",
                _ => value.ToString() ?? string.Empty
            };
        }

        private static string Escape(string value)
        {
            var normalized = value.Replace("\"", "\"\"");
            return $"\"{normalized}\"";
        }
    }
}
