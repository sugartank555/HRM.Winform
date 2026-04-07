using System.Drawing.Printing;
using System.Text;

namespace HRM.Winform.Helpers
{
    public static class PayslipDocumentHelper
    {
        public static void Print(IWin32Window owner, SalaryRowDto salary, int month, int year)
        {
            using var printDocument = new PrintDocument();
            printDocument.DocumentName = $"PhieuLuong_{salary.MaNhanVien}_{year}{month:00}";
            printDocument.PrintPage += (_, e) => DrawPayslip(e.Graphics, e.MarginBounds, salary, month, year);

            using var dialog = new PrintDialog
            {
                Document = printDocument,
                AllowSomePages = false,
                UseEXDialog = true
            };

            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        public static void ExportPdf(IWin32Window owner, SalaryRowDto salary, int month, int year)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "PDF (*.pdf)|*.pdf",
                FileName = $"phieu_luong_{salary.MaNhanVien}_{year}{month:00}.pdf",
                Title = "Xuat PDF phieu luong"
            };

            if (dialog.ShowDialog(owner) != DialogResult.OK)
            {
                return;
            }

            WriteSimplePdf(dialog.FileName, salary, month, year);
            MessageBox.Show("Da xuat PDF phieu luong thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void DrawPayslip(Graphics graphics, Rectangle bounds, SalaryRowDto salary, int month, int year)
        {
            graphics.Clear(Color.White);

            using var titleFont = new Font("Segoe UI", 22F, FontStyle.Bold);
            using var subtitleFont = new Font("Segoe UI", 11F, FontStyle.Regular);
            using var labelFont = new Font("Segoe UI", 11F, FontStyle.Regular);
            using var valueFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            using var totalFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            using var mutedBrush = new SolidBrush(Color.FromArgb(100, 116, 139));
            using var darkBrush = new SolidBrush(Color.FromArgb(15, 23, 42));
            using var accentBrush = new SolidBrush(Color.FromArgb(27, 110, 223));
            using var totalBack = new SolidBrush(Color.FromArgb(236, 253, 245));
            using var totalBorder = new Pen(Color.FromArgb(167, 243, 208));

            int x = bounds.Left;
            int y = bounds.Top;
            int width = bounds.Width;

            graphics.DrawString("HRM HUMAN RESOURCE MANAGER", valueFont, accentBrush, x, y);
            y += 34;
            graphics.DrawString("PHIEU LUONG CA NHAN", titleFont, darkBrush, x, y);
            y += 44;
            graphics.DrawString($"Ky luong thang {month:00}/{year}", subtitleFont, mutedBrush, x, y);
            y += 42;

            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Ho ten", salary.HoTen);
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Ma nhan vien", salary.MaNhanVien);
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Phong ban", salary.PhongBan);
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Chuc vu", salary.ChucVu);
            y += 42;

            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Luong co ban", FormatMoney(salary.LuongCoBan));
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Ngay cong huong luong", $"{salary.NgayCongHuongLuong:N1} ngay");
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Nghi co luong", $"{salary.NghiHuongLuong:N1} ngay");
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Nghi khong luong / vang", $"{salary.NghiKhongLuong:N1} ngay");
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Tong gio tang ca", $"{salary.TongGioTangCa:N1} gio");
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Tien tang ca", FormatMoney(salary.TienTangCa));
            y += 28;
            DrawLine(graphics, labelFont, valueFont, darkBrush, x, y, width, "Tong khau tru", FormatMoney(salary.TongKhauTru));
            y += 48;

            var totalRect = new Rectangle(x, y, width - 20, 64);
            graphics.FillRectangle(totalBack, totalRect);
            graphics.DrawRectangle(totalBorder, totalRect);
            graphics.DrawString($"Luong thuc nhan: {FormatMoney(salary.LuongThucNhan)}", totalFont, darkBrush, totalRect.X + 16, totalRect.Y + 16);
        }

        private static void DrawLine(Graphics graphics, Font labelFont, Font valueFont, Brush brush, int x, int y, int width, string label, string value)
        {
            graphics.DrawString(label + ":", labelFont, brush, x, y);
            graphics.DrawString(value, valueFont, brush, x + (width / 2), y);
        }

        private static void WriteSimplePdf(string path, SalaryRowDto salary, int month, int year)
        {
            var lines = new[]
            {
                "HRM HUMAN RESOURCE MANAGER",
                "PHIEU LUONG CA NHAN",
                $"Ky luong thang {month:00}/{year}",
                "",
                $"Ho ten: {salary.HoTen}",
                $"Ma nhan vien: {salary.MaNhanVien}",
                $"Phong ban: {salary.PhongBan}",
                $"Chuc vu: {salary.ChucVu}",
                "",
                $"Luong co ban: {FormatMoney(salary.LuongCoBan)}",
                $"Ngay cong huong luong: {salary.NgayCongHuongLuong:N1} ngay",
                $"Nghi co luong: {salary.NghiHuongLuong:N1} ngay",
                $"Nghi khong luong / vang: {salary.NghiKhongLuong:N1} ngay",
                $"Tong gio tang ca: {salary.TongGioTangCa:N1} gio",
                $"Tien tang ca: {FormatMoney(salary.TienTangCa)}",
                $"Tong khau tru: {FormatMoney(salary.TongKhauTru)}",
                "",
                $"Luong thuc nhan: {FormatMoney(salary.LuongThucNhan)}"
            };

            var content = new StringBuilder();
            content.AppendLine("BT");
            content.AppendLine("/F1 12 Tf");
            content.AppendLine("50 780 Td");
            foreach (var line in lines)
            {
                content.AppendLine($"({EscapePdfText(line)}) Tj");
                content.AppendLine("0 -22 Td");
            }
            content.AppendLine("ET");

            byte[] streamBytes = Encoding.ASCII.GetBytes(content.ToString());
            var pdf = new StringBuilder();
            var offsets = new List<int>();

            void AppendObject(string text)
            {
                offsets.Add(Encoding.ASCII.GetByteCount(pdf.ToString()));
                pdf.Append(text);
            }

            pdf.Append("%PDF-1.4\n");
            AppendObject("1 0 obj\n<< /Type /Catalog /Pages 2 0 R >>\nendobj\n");
            AppendObject("2 0 obj\n<< /Type /Pages /Kids [3 0 R] /Count 1 >>\nendobj\n");
            AppendObject("3 0 obj\n<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Contents 4 0 R /Resources << /Font << /F1 5 0 R >> >> >>\nendobj\n");
            AppendObject($"4 0 obj\n<< /Length {streamBytes.Length} >>\nstream\n{content}endstream\nendobj\n");
            AppendObject("5 0 obj\n<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>\nendobj\n");

            int xrefOffset = Encoding.ASCII.GetByteCount(pdf.ToString());
            pdf.Append("xref\n");
            pdf.Append($"0 {offsets.Count + 1}\n");
            pdf.Append("0000000000 65535 f \n");
            foreach (int offset in offsets)
            {
                pdf.Append(offset.ToString("D10"));
                pdf.Append(" 00000 n \n");
            }
            pdf.Append("trailer\n");
            pdf.Append($"<< /Size {offsets.Count + 1} /Root 1 0 R >>\n");
            pdf.Append("startxref\n");
            pdf.Append(xrefOffset);
            pdf.Append("\n%%EOF");

            File.WriteAllText(path, pdf.ToString(), Encoding.ASCII);
        }

        private static string EscapePdfText(string text)
        {
            return text
                .Replace("\\", "\\\\")
                .Replace("(", "\\(")
                .Replace(")", "\\)");
        }

        private static string FormatMoney(decimal value)
        {
            return $"{value:N0} VND";
        }
    }
}
