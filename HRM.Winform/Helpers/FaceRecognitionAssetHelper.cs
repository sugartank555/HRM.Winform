namespace HRM.Winform.Helpers
{
    public sealed class FaceRecognitionAssetConfig
    {
        public string ScriptSource { get; set; } = string.Empty;
        public string ModelSource { get; set; } = string.Empty;
        public bool IsOfflineReady { get; set; }
        public string StatusText { get; set; } = string.Empty;
    }

    public static class FaceRecognitionAssetHelper
    {
        public static string GetAssetRoot()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "FaceAssets");

            Directory.CreateDirectory(root);
            return root;
        }

        public static string GetScriptPath()
        {
            return Path.Combine(GetAssetRoot(), "face-api.min.js");
        }

        public static string GetModelDirectory()
        {
            string path = Path.Combine(GetAssetRoot(), "models");
            Directory.CreateDirectory(path);
            return path;
        }

        public static FaceRecognitionAssetConfig ResolveForWebView()
        {
            bool hasScript = File.Exists(GetScriptPath());
            bool hasModels = Directory.Exists(GetModelDirectory()) && Directory.EnumerateFiles(GetModelDirectory()).Any();

            if (hasScript && hasModels)
            {
                return new FaceRecognitionAssetConfig
                {
                    ScriptSource = "/assets/face-api.min.js",
                    ModelSource = "/assets/models",
                    IsOfflineReady = true,
                    StatusText = "Dang dung tai nguyen khuon mat local, co the demo offline."
                };
            }

            return new FaceRecognitionAssetConfig
            {
                ScriptSource = "https://cdn.jsdelivr.net/npm/face-api.js/dist/face-api.min.js",
                ModelSource = "https://justadudewhohacks.github.io/face-api.js/models",
                IsOfflineReady = false,
                StatusText = "Dang fallback online cho face-api.js/model. Co the chep tai nguyen local de demo offline on dinh hon."
            };
        }
    }
}
