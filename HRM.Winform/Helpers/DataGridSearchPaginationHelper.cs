using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HRM.Winform.Helpers
{
    public sealed class DataGridSearchPaginationHelper
    {
        private readonly DataGridView _grid;
        private readonly Control _parent;
        private readonly Panel _topPanel;
        private readonly Panel _bottomPanel;
        private readonly TextBox _txtSearch;
        private readonly ComboBox _cboPageSize;
        private readonly Label _lblSummary;
        private readonly Label _lblPageInfo;
        private readonly Button _btnPrev;
        private readonly Button _btnNext;
        private readonly int _left;
        private readonly int _top;
        private readonly int _right;
        private readonly int _bottom;

        private DataTable _fullTable = new();
        private List<DataRow> _filteredRows = new();
        private int _currentPage = 1;
        private bool _updating;

        public DataGridSearchPaginationHelper(DataGridView grid, string searchPlaceholder = "Tim kiem nhanh...")
        {
            _grid = grid;
            _parent = grid.Parent ?? throw new InvalidOperationException("Grid must have a parent control.");

            _left = grid.Left;
            _top = grid.Top;
            _right = _parent.ClientSize.Width - (grid.Left + grid.Width);
            _bottom = _parent.ClientSize.Height - (grid.Top + grid.Height);

            _topPanel = new Panel
            {
                Height = 36,
                BackColor = Color.Transparent
            };

            _bottomPanel = new Panel
            {
                Height = 38,
                BackColor = Color.Transparent
            };

            _txtSearch = new TextBox
            {
                PlaceholderText = searchPlaceholder,
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle
            };
            _txtSearch.TextChanged += (_, _) => RefreshView(1);

            _cboPageSize = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5F),
                Width = 72
            };
            _cboPageSize.Items.AddRange(new object[] { 10, 20, 50, 100 });
            _cboPageSize.SelectedIndex = 0;
            _cboPageSize.SelectedIndexChanged += (_, _) => RefreshView(1);

            _lblSummary = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 9.25F),
                ForeColor = Color.FromArgb(76, 89, 112)
            };

            _lblPageInfo = new Label
            {
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI Semibold", 9.25F),
                ForeColor = Color.FromArgb(33, 37, 41)
            };

            _btnPrev = CreatePagerButton("Truoc");
            _btnPrev.Click += (_, _) =>
            {
                if (_currentPage > 1)
                {
                    RefreshView(_currentPage - 1);
                }
            };

            _btnNext = CreatePagerButton("Sau");
            _btnNext.Click += (_, _) =>
            {
                if (_currentPage < GetTotalPages())
                {
                    RefreshView(_currentPage + 1);
                }
            };

            _topPanel.Controls.Add(_txtSearch);
            _bottomPanel.Controls.Add(_lblSummary);
            _bottomPanel.Controls.Add(_cboPageSize);
            _bottomPanel.Controls.Add(_lblPageInfo);
            _bottomPanel.Controls.Add(_btnPrev);
            _bottomPanel.Controls.Add(_btnNext);

            _parent.Controls.Add(_topPanel);
            _parent.Controls.Add(_bottomPanel);

            ApplyTheme();
            RefreshLayout();

            _parent.Resize += (_, _) => RefreshLayout();
        }

        public void ApplyData(IEnumerable<object?> source)
        {
            _fullTable = ConvertToDataTable(source);
            RefreshView(1);
        }

        public void ApplyData(System.Collections.IEnumerable source)
        {
            var items = new List<object?>();
            foreach (var item in source)
            {
                items.Add(item);
            }

            ApplyData(items);
        }

        private void ApplyTheme()
        {
            _topPanel.BackColor = Color.White;
            _bottomPanel.BackColor = Color.White;

            _txtSearch.BackColor = Color.White;
            _txtSearch.ForeColor = Color.FromArgb(33, 37, 41);

            _cboPageSize.BackColor = Color.White;
            _cboPageSize.ForeColor = Color.FromArgb(33, 37, 41);
        }

        public void RefreshLayout()
        {
            int frameWidth = Math.Max(200, _parent.ClientSize.Width - _left - _right);
            int frameHeight = Math.Max(160, _parent.ClientSize.Height - _top - _bottom);
            int topHeight = _topPanel.Height;
            int bottomHeight = _bottomPanel.Height;
            int gap = 8;

            _topPanel.SetBounds(_left, _top, frameWidth, topHeight);
            _bottomPanel.SetBounds(_left, _top + frameHeight - bottomHeight, frameWidth, bottomHeight);

            _txtSearch.SetBounds(0, 4, Math.Min(320, frameWidth), 28);

            _lblSummary.SetBounds(0, 7, Math.Min(360, frameWidth / 2), 24);
            _cboPageSize.SetBounds(Math.Max(0, _lblSummary.Right + 8), 5, 72, 28);

            int pagerWidth = 230;
            int pagerLeft = Math.Max(_cboPageSize.Right + 8, frameWidth - pagerWidth);

            _btnPrev.SetBounds(pagerLeft, 5, 68, 28);
            _lblPageInfo.SetBounds(_btnPrev.Right + gap, 7, 74, 24);
            _btnNext.SetBounds(_lblPageInfo.Right + gap, 5, 68, 28);

            _grid.SetBounds(
                _left,
                _top + topHeight + gap,
                frameWidth,
                Math.Max(80, frameHeight - topHeight - bottomHeight - (gap * 2)));

            _grid.BringToFront();
            _topPanel.BringToFront();
            _bottomPanel.BringToFront();
        }

        private Button CreatePagerButton(string text)
        {
            return new Button
            {
                Text = text,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI Semibold", 9F),
                BackColor = Color.FromArgb(238, 243, 255),
                ForeColor = Color.FromArgb(44, 91, 255),
                Cursor = Cursors.Hand
            };
        }

        private void RefreshView(int page)
        {
            if (_updating)
            {
                return;
            }

            _updating = true;
            try
            {
                string keyword = Normalize(_txtSearch.Text.Trim());
                _filteredRows = string.IsNullOrWhiteSpace(keyword)
                    ? _fullTable.Rows.Cast<DataRow>().ToList()
                    : _fullTable.Rows.Cast<DataRow>()
                        .Where(row => RowMatches(row, keyword))
                        .ToList();

                int totalPages = GetTotalPages();
                _currentPage = Math.Max(1, Math.Min(page, totalPages));

                var pageTable = _fullTable.Clone();
                int pageSize = GetPageSize();
                int skip = (_currentPage - 1) * pageSize;

                foreach (var row in _filteredRows.Skip(skip).Take(pageSize))
                {
                    pageTable.ImportRow(row);
                }

                _grid.DataSource = pageTable;
                UpdatePagerText();
            }
            finally
            {
                _updating = false;
            }
        }

        private void UpdatePagerText()
        {
            int total = _filteredRows.Count;
            int pageSize = GetPageSize();
            int from = total == 0 ? 0 : ((_currentPage - 1) * pageSize) + 1;
            int to = Math.Min(total, _currentPage * pageSize);

            _lblSummary.Text = $"Hien thi {from}-{to} / {total} ban ghi";
            _lblPageInfo.Text = $"{_currentPage}/{GetTotalPages()}";
            _btnPrev.Enabled = _currentPage > 1;
            _btnNext.Enabled = _currentPage < GetTotalPages();
        }

        private int GetPageSize()
        {
            return _cboPageSize.SelectedItem is int pageSize ? pageSize : 10;
        }

        private int GetTotalPages()
        {
            int total = _filteredRows.Count;
            int pageSize = GetPageSize();
            return Math.Max(1, (int)Math.Ceiling(total / (double)pageSize));
        }

        private static bool RowMatches(DataRow row, string keyword)
        {
            foreach (DataColumn column in row.Table.Columns)
            {
                if (row.IsNull(column))
                {
                    continue;
                }

                string text = Normalize(Convert.ToString(row[column], CultureInfo.InvariantCulture) ?? string.Empty);
                if (text.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private static string Normalize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            string normalized = value.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder(normalized.Length);
            foreach (char ch in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(ch);
                }
            }

            string result = builder.ToString().Normalize(NormalizationForm.FormC);
            result = result.Replace('đ', 'd').Replace('Đ', 'D');
            return Regex.Replace(result, "\\s+", " ").Trim();
        }

        private static DataTable ConvertToDataTable(IEnumerable<object?> source)
        {
            var items = source.ToList();
            Type? itemType = ResolveItemType(items, source);
            var table = new DataTable();

            if (itemType == null)
            {
                return table;
            }

            var properties = itemType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && IsSupportedPropertyType(p.PropertyType))
                .ToArray();

            foreach (var property in properties)
            {
                table.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            foreach (var item in items)
            {
                var row = table.NewRow();
                if (item != null)
                {
                    foreach (var property in properties)
                    {
                        object? value = property.GetValue(item);
                        row[property.Name] = value ?? DBNull.Value;
                    }
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private static Type? ResolveItemType(List<object?> items, IEnumerable<object?> source)
        {
            var sample = items.FirstOrDefault(item => item != null);
            if (sample != null)
            {
                return sample.GetType();
            }

            Type sourceType = source.GetType();
            if (sourceType.IsGenericType)
            {
                return sourceType.GetGenericArguments().FirstOrDefault();
            }

            return null;
        }

        private static bool IsSupportedPropertyType(Type type)
        {
            Type actualType = Nullable.GetUnderlyingType(type) ?? type;
            return actualType.IsPrimitive
                || actualType.IsEnum
                || actualType == typeof(string)
                || actualType == typeof(decimal)
                || actualType == typeof(DateTime)
                || actualType == typeof(Guid)
                || actualType == typeof(TimeSpan);
        }
    }
}
