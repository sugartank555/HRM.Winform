using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using HRM.Winform.Helpers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HRM.Winform.Forms.CaNhan
{
    public sealed class FaceCaptureResult
    {
        [JsonPropertyName("descriptor")]
        public float[] Descriptor { get; set; } = Array.Empty<float>();

        [JsonPropertyName("imageDataUrl")]
        public string ImageDataUrl { get; set; } = string.Empty;
    }

    public class FrmCameraKhuonMat : Form
    {
        private readonly string _title;
        private readonly string _instruction;
        private readonly WebView2 _webView;
        private readonly Label _lblStatus;
        private readonly Button _btnDong;
        private FaceRecognitionAssetConfig? _assetConfig;

        public FaceCaptureResult? CaptureResult { get; private set; }

        public FrmCameraKhuonMat(string title, string instruction)
        {
            _title = title;
            _instruction = instruction;

            Text = title;
            StartPosition = FormStartPosition.CenterParent;
            Width = 960;
            Height = 760;
            BackColor = Color.White;

            _lblStatus = new Label
            {
                Dock = DockStyle.Top,
                Height = 48,
                Padding = new Padding(16, 14, 16, 0),
                Font = new Font("Segoe UI", 10F),
                Text = "Dang khoi tao camera..."
            };

            _btnDong = new Button
            {
                Dock = DockStyle.Bottom,
                Height = 42,
                Text = "Dong"
            };
            _btnDong.Click += (_, _) => Close();

            _webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(_webView);
            Controls.Add(_btnDong);
            Controls.Add(_lblStatus);

            Load += FrmCameraKhuonMat_Load;
        }

        private async void FrmCameraKhuonMat_Load(object? sender, EventArgs e)
        {
            try
            {
                await _webView.EnsureCoreWebView2Async();
                _webView.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;
                _webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
                _assetConfig = FaceRecognitionAssetHelper.ResolveForWebView();
                string pageUrl = PrepareLocalPage();
                _webView.CoreWebView2.Navigate(pageUrl);
                _lblStatus.Text = _assetConfig.StatusText;
            }
            catch (Exception ex)
            {
                _lblStatus.Text = $"Khong khoi tao duoc camera: {ex.Message}";
            }
        }

        private void CoreWebView2_PermissionRequested(object? sender, CoreWebView2PermissionRequestedEventArgs e)
        {
            if (e.PermissionKind == CoreWebView2PermissionKind.Camera || e.PermissionKind == CoreWebView2PermissionKind.Microphone)
            {
                e.State = CoreWebView2PermissionState.Allow;
            }
        }

        private void CoreWebView2_WebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            string msg = e.TryGetWebMessageAsString();
            if (string.IsNullOrWhiteSpace(msg))
            {
                return;
            }

            if (msg.StartsWith("ERR:", StringComparison.OrdinalIgnoreCase))
            {
                _lblStatus.Text = msg[4..];
                return;
            }

            if (!msg.StartsWith("FACE:", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            try
            {
                string payload = msg[5..];
                CaptureResult = JsonSerializer.Deserialize<FaceCaptureResult>(payload, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (CaptureResult != null && CaptureResult.Descriptor.Length > 0 && !string.IsNullOrWhiteSpace(CaptureResult.ImageDataUrl))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                _lblStatus.Text = "Du lieu khuon mat chua hop le. Thu chup lai.";
            }
            catch (Exception ex)
            {
                _lblStatus.Text = $"Doc du lieu khuon mat that bai: {ex.Message}";
            }
        }

        private string PrepareLocalPage()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "WebViewAssets",
                "FaceCamera");

            Directory.CreateDirectory(root);
            string htmlPath = Path.Combine(root, "index.html");
            var assetConfig = _assetConfig ?? FaceRecognitionAssetHelper.ResolveForWebView();
            File.WriteAllText(htmlPath, TaoHtml(_title, _instruction, assetConfig), Encoding.UTF8);

            _webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "hrm-face.local",
                root,
                CoreWebView2HostResourceAccessKind.Allow);

            _webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "hrm-face-assets.local",
                FaceRecognitionAssetHelper.GetAssetRoot(),
                CoreWebView2HostResourceAccessKind.Allow);

            return "https://hrm-face.local/index.html";
        }

        private static string TaoHtml(string title, string instruction, FaceRecognitionAssetConfig assetConfig)
        {
            string escTitle = title.Replace("'", "\\'");
            string escInstruction = instruction.Replace("'", "\\'");
            string escAssetStatus = assetConfig.StatusText.Replace("'", "\\'");
            string scriptSrc = assetConfig.IsOfflineReady
                ? "https://hrm-face-assets.local/face-api.min.js"
                : assetConfig.ScriptSource;
            string modelUrl = assetConfig.IsOfflineReady
                ? "https://hrm-face-assets.local/models"
                : assetConfig.ModelSource;

            return $$"""
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <style>
    body { margin: 0; font-family: Segoe UI, sans-serif; background: #0f172a; color: white; }
    .wrap { display: flex; flex-direction: column; height: 100vh; }
    .top { padding: 14px 18px; background: #111827; font-size: 14px; }
    .stage { flex: 1; position: relative; overflow: hidden; }
    video { width: 100%; height: 100%; object-fit: cover; background: black; transform: scaleX(-1); }
    canvas { display:none; }
    .box { position: absolute; inset: 12% 27%; border: 4px solid #22c55e; border-radius: 24px; box-shadow: 0 0 0 9999px rgba(0,0,0,.32); }
    .tip { position: absolute; left: 20px; right: 20px; bottom: 84px; padding: 12px 14px; border-radius: 12px; background: rgba(15,23,42,.78); }
    .asset { position: absolute; left: 20px; top: 20px; padding: 8px 12px; border-radius: 10px; background: rgba(15,23,42,.78); color: #bfdbfe; font-size: 13px; }
    .actions { position: absolute; left: 20px; right: 20px; bottom: 20px; display: flex; gap: 12px; }
    button { border: none; border-radius: 12px; padding: 12px 18px; font-size: 15px; cursor: pointer; }
    .primary { background: #2563eb; color: white; }
    .secondary { background: white; color: #1e3a8a; }
  </style>
</head>
<body>
  <div class="wrap">
    <div class="top" id="status">{{escTitle}} - dang xin quyen truy cap camera...</div>
    <div class="stage">
      <video id="video" autoplay playsinline muted></video>
      <canvas id="canvas"></canvas>
      <div class="asset">{{escAssetStatus}}</div>
      <div class="box"></div>
      <div class="tip">{{escInstruction}}. Dat mat vao khung xanh, nhin thang vao camera, giu sang on dinh.</div>
      <div class="actions">
        <button class="primary" id="btnCapture">Chup va xac thuc</button>
        <button class="secondary" id="btnRetry">Tai lai camera</button>
      </div>
    </div>
  </div>
  <script src="{{scriptSrc}}"></script>
  <script>
    const statusEl = document.getElementById('status');
    const video = document.getElementById('video');
    const canvas = document.getElementById('canvas');
    const ctx = canvas.getContext('2d');
    const btnCapture = document.getElementById('btnCapture');
    const btnRetry = document.getElementById('btnRetry');
    let modelsReady = false;
    btnCapture.disabled = true;

    function post(msg) {
      window.chrome.webview.postMessage(msg);
    }

    async function loadModels() {
      const modelUrl = '{{modelUrl}}';
      try {
        if (!window.faceapi) {
          throw new Error('Khong nap duoc face-api.js');
        }
        await faceapi.nets.tinyFaceDetector.loadFromUri(modelUrl);
        await faceapi.nets.faceLandmark68Net.loadFromUri(modelUrl);
        await faceapi.nets.faceRecognitionNet.loadFromUri(modelUrl);
        modelsReady = true;
        btnCapture.disabled = false;
      } catch (err) {
        post('ERR:Khong tai duoc model nhan dien khuon mat. Neu muon demo offline, hay chep face-api.min.js va cac model vao LocalAppData\\\\HRM.Winform\\\\FaceAssets. ' + err.message);
      }
    }

    async function startCamera() {
      try {
        const stream = await navigator.mediaDevices.getUserMedia({
          video: { facingMode: 'user' },
          audio: false
        });
        video.srcObject = stream;
        await video.play();
        statusEl.textContent = '{{escTitle}} - san sang chup.';
      } catch (err) {
        post('ERR:Khong mo duoc camera. ' + err.message);
      }
    }

    async function captureFace() {
      if (!modelsReady) {
        post('ERR:Model khuon mat chua san sang.');
        return;
      }

      if (video.readyState !== video.HAVE_ENOUGH_DATA) {
        post('ERR:Camera chua san sang.');
        return;
      }

      canvas.width = video.videoWidth;
      canvas.height = video.videoHeight;
      ctx.drawImage(video, 0, 0, canvas.width, canvas.height);

      const detection = await faceapi
        .detectSingleFace(canvas, new faceapi.TinyFaceDetectorOptions())
        .withFaceLandmarks()
        .withFaceDescriptor();

      if (!detection) {
        post('ERR:Khong tim thay khuon mat ro rang. Thu lai voi anh sang tot hon.');
        return;
      }

      const descriptor = Array.from(detection.descriptor);
      const imageDataUrl = canvas.toDataURL('image/jpeg', 0.92);
      post('FACE:' + JSON.stringify({ descriptor, imageDataUrl }));
    }

    btnCapture.addEventListener('click', captureFace);
    btnRetry.addEventListener('click', async () => {
      statusEl.textContent = '{{escTitle}} - dang tai lai camera...';
      await startCamera();
    });

    window.addEventListener('load', async () => {
      await loadModels();
      await startCamera();
    });
  </script>
</body>
</html>
""";
        }
    }
}
