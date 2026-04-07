using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.Text;

namespace HRM.Winform.Forms.CaNhan
{
    public class FrmQuetQrCamera : Form
    {
        private readonly WebView2 _webView;
        private readonly Label _lblTrangThai;
        private readonly Button _btnDong;

        public string? MaQrDaQuet { get; private set; }

        public FrmQuetQrCamera()
        {
            Text = "Quet QR bang camera";
            StartPosition = FormStartPosition.CenterParent;
            Width = 900;
            Height = 700;
            BackColor = Color.White;

            _lblTrangThai = new Label
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
            Controls.Add(_lblTrangThai);

            Load += FrmQuetQrCamera_Load;
        }

        private async void FrmQuetQrCamera_Load(object? sender, EventArgs e)
        {
            try
            {
                await _webView.EnsureCoreWebView2Async();
                _webView.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;
                _webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
                string pageUrl = PrepareLocalPage();
                _webView.CoreWebView2.Navigate(pageUrl);
                _lblTrangThai.Text = "Huong camera vao ma QR de quet.";
            }
            catch (Exception ex)
            {
                _lblTrangThai.Text = $"Khong khoi tao duoc camera: {ex.Message}";
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

            if (msg.StartsWith("QR:", StringComparison.OrdinalIgnoreCase))
            {
                MaQrDaQuet = msg[3..];
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (msg.StartsWith("ERR:", StringComparison.OrdinalIgnoreCase))
            {
                _lblTrangThai.Text = msg[4..];
            }
        }

        private string PrepareLocalPage()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "WebViewAssets",
                "QrCamera");

            Directory.CreateDirectory(root);
            string htmlPath = Path.Combine(root, "index.html");
            File.WriteAllText(htmlPath, TaoHtmlQuetQr(), Encoding.UTF8);

            _webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "hrm-qr.local",
                root,
                CoreWebView2HostResourceAccessKind.Allow);

            return "https://hrm-qr.local/index.html";
        }

        private static string TaoHtmlQuetQr()
        {
            return """
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
    video { width: 100%; height: 100%; object-fit: cover; background: black; }
    .box { position: absolute; inset: 15% 20%; border: 4px solid #22c55e; border-radius: 18px; box-shadow: 0 0 0 9999px rgba(0,0,0,.35); }
    .tip { position: absolute; left: 20px; right: 20px; bottom: 20px; padding: 12px 14px; border-radius: 12px; background: rgba(15,23,42,.8); }
  </style>
</head>
<body>
  <div class="wrap">
      <div class="top" id="status">Dang xin quyen truy cap camera...</div>
    <div class="stage">
      <video id="video" autoplay playsinline muted></video>
      <canvas id="canvas" style="display:none;"></canvas>
      <div class="box"></div>
      <div class="tip">Dat ma QR vao giua khung xanh. Neu may khong ho tro BarcodeDetector, he thong se thu fallback sang jsQR.</div>
    </div>
  </div>
  <script src="https://cdn.jsdelivr.net/npm/jsqr/dist/jsQR.js"></script>
  <script>
    const statusEl = document.getElementById('status');
    const video = document.getElementById('video');
    const canvas = document.getElementById('canvas');
    const ctx = canvas.getContext('2d');
    let detector = null;
    let scanning = false;
    let useJsQrFallback = false;

    function post(msg) {
      window.chrome.webview.postMessage(msg);
    }

    async function start() {
      if ('BarcodeDetector' in window) {
        try {
          detector = new BarcodeDetector({ formats: ['qr_code'] });
          statusEl.textContent = 'Dang quet QR bang BarcodeDetector...';
        } catch {
          detector = null;
        }
      }

      if (!detector) {
        if (typeof jsQR !== 'function') {
          post('ERR:May khong ho tro BarcodeDetector va khong tai duoc jsQR fallback.');
          return;
        }

        useJsQrFallback = true;
        statusEl.textContent = 'Dang quet QR bang jsQR fallback...';
      }

      try {
        const stream = await navigator.mediaDevices.getUserMedia({
          video: { facingMode: 'environment' },
          audio: false
        });
        video.srcObject = stream;
        await video.play();
        statusEl.textContent = 'Dang quet QR...';
        scanning = true;
        requestAnimationFrame(scanLoop);
      } catch (err) {
        post('ERR:Khong mo duoc camera. ' + err.message);
      }
    }

    async function scanLoop() {
      if (!scanning) return;
      try {
        if (detector) {
          const codes = await detector.detect(video);
          if (codes && codes.length > 0 && codes[0].rawValue) {
            scanning = false;
            statusEl.textContent = 'Quet thanh cong.';
            post('QR:' + codes[0].rawValue);
            return;
          }
        } else if (useJsQrFallback) {
          if (video.readyState === video.HAVE_ENOUGH_DATA) {
            canvas.width = video.videoWidth;
            canvas.height = video.videoHeight;
            ctx.drawImage(video, 0, 0, canvas.width, canvas.height);
            const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
            const code = jsQR(imageData.data, imageData.width, imageData.height);
            if (code && code.data) {
              scanning = false;
              statusEl.textContent = 'Quet thanh cong bang jsQR.';
              post('QR:' + code.data);
              return;
            }
          }
        }
      } catch {}
      requestAnimationFrame(scanLoop);
    }

    start();
  </script>
</body>
</html>
""";
        }
    }
}
