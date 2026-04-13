using HRM.Winform.Helpers;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System.
    Globalization;
using System.Text;

namespace HRM.Winform.Forms.CaNhan
{
    public class FrmXacThucGps : Form
    {
        private readonly WebView2 _webView;
        private readonly Label _lblStatus;
        private readonly Button _btnLayLai;
        private readonly Button _btnDong;

        public GpsCaptureResult? GpsResult { get; private set; }

        public FrmXacThucGps()
        {
            Text = "Xac thuc GPS";
            StartPosition = FormStartPosition.CenterParent;
            Width = 900;
            Height = 620;
            BackColor = Color.White;

            _lblStatus = new Label
            {
                Dock = DockStyle.Top,
                Height = 56,
                Padding = new Padding(16, 16, 16, 0),
                Font = new Font("Segoe UI", 10F),
                Text = "Dang khoi tao vi tri..."
            };

            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 52
            };

            _btnLayLai = new Button
            {
                Text = "Lay lai vi tri",
                Width = 130,
                Height = 36,
                Left = 16,
                Top = 8
            };
            _btnLayLai.Click += (_, _) => _webView.CoreWebView2?.PostWebMessageAsString("refresh-location");

            _btnDong = new Button
            {
                Text = "Dong",
                Width = 110,
                Height = 36,
                Left = 160,
                Top = 8
            };
            _btnDong.Click += (_, _) => Close();

            pnlBottom.Controls.Add(_btnLayLai);
            pnlBottom.Controls.Add(_btnDong);

            _webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(_webView);
            Controls.Add(pnlBottom);
            Controls.Add(_lblStatus);

            Load += FrmXacThucGps_Load;
        }

        private async void FrmXacThucGps_Load(object? sender, EventArgs e)
        {
            try
            {
                await _webView.EnsureCoreWebView2Async();
                _webView.CoreWebView2.PermissionRequested += CoreWebView2_PermissionRequested;
                _webView.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;
                string url = PrepareLocalPage();
                _webView.CoreWebView2.Navigate(url);
                _lblStatus.Text = "Dang lay vi tri hien tai tu thiet bi...";
            }
            catch (Exception ex)
            {
                _lblStatus.Text = $"Khong khoi tao duoc GPS: {ex.Message}";
            }
        }

        private void CoreWebView2_PermissionRequested(object? sender, CoreWebView2PermissionRequestedEventArgs e)
        {
            if (e.PermissionKind == CoreWebView2PermissionKind.Geolocation)
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

            if (!msg.StartsWith("GPS:", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var payload = msg[4..].Split('|');
            if (payload.Length < 3)
            {
                _lblStatus.Text = "Du lieu GPS khong hop le.";
                return;
            }

            if (!double.TryParse(payload[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double latitude) ||
                !double.TryParse(payload[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double longitude) ||
                !double.TryParse(payload[2], NumberStyles.Float, CultureInfo.InvariantCulture, out double accuracy))
            {
                _lblStatus.Text = "Khong doc duoc toa do GPS.";
                return;
            }

            GpsResult = new GpsCaptureResult
            {
                Latitude = latitude,
                Longitude = longitude,
                AccuracyMeters = accuracy
            };

            _lblStatus.Text = $"Da lay vi tri: {latitude:F6}, {longitude:F6} | Sai so ~ {accuracy:N0} m";
            DialogResult = DialogResult.OK;
            Close();
        }

        private string PrepareLocalPage()
        {
            string root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "HRM.Winform",
                "WebViewAssets",
                "GpsLocation");

            Directory.CreateDirectory(root);
            string htmlPath = Path.Combine(root, "index.html");
            File.WriteAllText(htmlPath, TaoHtml(), Encoding.UTF8);

            _webView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "hrm-gps.local",
                root,
                CoreWebView2HostResourceAccessKind.Allow);

            return "https://hrm-gps.local/index.html";
        }

        private static string TaoHtml()
        {
            return """
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <style>
    body { margin: 0; font-family: Segoe UI, sans-serif; background: #0f172a; color: white; }
    .wrap { padding: 24px; }
    .card { background: #111827; border-radius: 18px; padding: 20px; margin: 18px; }
    .title { font-size: 20px; font-weight: 700; margin-bottom: 8px; }
    .muted { color: #cbd5e1; line-height: 1.6; }
    .box { height: 260px; border: 3px dashed #22c55e; border-radius: 20px; margin-top: 24px; display: flex; align-items: center; justify-content: center; font-size: 18px; color: #86efac; }
  </style>
</head>
<body>
  <div class="wrap">
    <div class="card">
      <div class="title">Lay vi tri GPS hien tai</div>
      <div class="muted">He thong se xin quyen vi tri tren Windows va lay toa do hien tai de doi chieu voi vi tri cong ty.</div>
      <div class="box" id="box">Dang lay vi tri...</div>
    </div>
  </div>
  <script>
    const box = document.getElementById('box');

    function post(message) {
      window.chrome.webview.postMessage(message);
    }

    function updateBox(text) {
      box.textContent = text;
    }

    function fetchLocation() {
      if (!navigator.geolocation) {
        post('ERR:Trinh duyet nhung khong ho tro geolocation.');
        updateBox('Khong ho tro geolocation');
        return;
      }

      updateBox('Dang xin quyen va lay toa do...');

      navigator.geolocation.getCurrentPosition(
        (position) => {
          const lat = position.coords.latitude;
          const lng = position.coords.longitude;
          const acc = position.coords.accuracy || 0;
          updateBox(`Lat ${lat.toFixed(6)} | Lng ${lng.toFixed(6)} | Sai so ${Math.round(acc)} m`);
          post(`GPS:${lat}|${lng}|${acc}`);
        },
        (error) => {
          const message = error && error.message ? error.message : 'Khong lay duoc vi tri.';
          updateBox(message);
          post(`ERR:Khong lay duoc vi tri GPS. ${message}`);
        },
        {
          enableHighAccuracy: true,
          timeout: 15000,
          maximumAge: 0
        });
    }

    window.chrome.webview.addEventListener('message', (event) => {
      if (event.data === 'refresh-location') {
        fetchLocation();
      }
    });

    window.addEventListener('load', fetchLocation);
  </script>
</body>
</html>
""";
        }
    }
}
