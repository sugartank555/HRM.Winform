using System.Text.Json;

namespace HRM.Winform.Helpers
{
    public sealed class FaceRegistrationResetRequest
    {
        public string RequestId { get; set; } = Guid.NewGuid().ToString("N");
        public int NhanVienId { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string RequestedBy { get; set; } = string.Empty;
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; } = "ChoDuyet";
        public string Note { get; set; } = string.Empty;
        public DateTime? ReviewedAt { get; set; }
        public string ReviewedBy { get; set; } = string.Empty;
        public string ReviewNote { get; set; } = string.Empty;
        public bool UnlockGranted { get; set; }
        public DateTime? UnlockGrantedAt { get; set; }
        public bool UnlockUsed { get; set; }
        public DateTime? UnlockUsedAt { get; set; }
    }

    public static class FaceRegistrationResetRequestStore
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        private static string DirectoryPath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HRM.Winform", "FaceResetRequests");

        private static string FilePath => Path.Combine(DirectoryPath, "requests.json");

        public static List<FaceRegistrationResetRequest> LoadAll()
        {
            try
            {
                if (!File.Exists(FilePath))
                {
                    return [];
                }

                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<FaceRegistrationResetRequest>>(json, JsonOptions) ?? [];
            }
            catch
            {
                return [];
            }
        }

        public static FaceRegistrationResetRequest? GetLatest(int nhanVienId)
        {
            return LoadAll()
                .Where(x => x.NhanVienId == nhanVienId)
                .OrderByDescending(x => x.RequestedAt)
                .FirstOrDefault();
        }

        public static FaceRegistrationResetRequest? GetPending(int nhanVienId)
        {
            return LoadAll()
                .Where(x => x.NhanVienId == nhanVienId && x.Status == "ChoDuyet")
                .OrderByDescending(x => x.RequestedAt)
                .FirstOrDefault();
        }

        public static FaceRegistrationResetRequest? GetApprovedUnlock(int nhanVienId)
        {
            return LoadAll()
                .Where(x => x.NhanVienId == nhanVienId && x.Status == "DaDuyet" && x.UnlockGranted && !x.UnlockUsed)
                .OrderByDescending(x => x.UnlockGrantedAt ?? x.ReviewedAt ?? x.RequestedAt)
                .FirstOrDefault();
        }

        public static FaceRegistrationResetRequest CreateRequest(int nhanVienId, string maNhanVien, string hoTen, string requestedBy, string note)
        {
            Directory.CreateDirectory(DirectoryPath);
            var items = LoadAll();

            var existingPending = items
                .FirstOrDefault(x => x.NhanVienId == nhanVienId && x.Status == "ChoDuyet");

            if (existingPending != null)
            {
                return existingPending;
            }

            var request = new FaceRegistrationResetRequest
            {
                NhanVienId = nhanVienId,
                MaNhanVien = maNhanVien,
                HoTen = hoTen,
                RequestedBy = requestedBy,
                RequestedAt = DateTime.Now,
                Note = note,
                Status = "ChoDuyet"
            };

            items.Add(request);
            SaveAll(items);
            return request;
        }

        public static void Approve(string requestId, string reviewedBy, string reviewNote)
        {
            var items = LoadAll();
            var request = items.FirstOrDefault(x => x.RequestId == requestId);
            if (request == null)
            {
                return;
            }

            request.Status = "DaDuyet";
            request.ReviewedBy = reviewedBy;
            request.ReviewedAt = DateTime.Now;
            request.ReviewNote = reviewNote;
            request.UnlockGranted = true;
            request.UnlockGrantedAt = DateTime.Now;
            request.UnlockUsed = false;
            request.UnlockUsedAt = null;
            SaveAll(items);
        }

        public static void Reject(string requestId, string reviewedBy, string reviewNote)
        {
            var items = LoadAll();
            var request = items.FirstOrDefault(x => x.RequestId == requestId);
            if (request == null)
            {
                return;
            }

            request.Status = "TuChoi";
            request.ReviewedBy = reviewedBy;
            request.ReviewedAt = DateTime.Now;
            request.ReviewNote = reviewNote;
            request.UnlockGranted = false;
            SaveAll(items);
        }

        public static void ConsumeUnlock(int nhanVienId)
        {
            var items = LoadAll();
            var request = items
                .Where(x => x.NhanVienId == nhanVienId && x.Status == "DaDuyet" && x.UnlockGranted && !x.UnlockUsed)
                .OrderByDescending(x => x.UnlockGrantedAt ?? x.ReviewedAt ?? x.RequestedAt)
                .FirstOrDefault();

            if (request == null)
            {
                return;
            }

            request.UnlockUsed = true;
            request.UnlockUsedAt = DateTime.Now;
            SaveAll(items);
        }

        private static void SaveAll(List<FaceRegistrationResetRequest> items)
        {
            Directory.CreateDirectory(DirectoryPath);
            var ordered = items
                .OrderByDescending(x => x.RequestedAt)
                .ToList();
            File.WriteAllText(FilePath, JsonSerializer.Serialize(ordered, JsonOptions));
        }
    }
}
