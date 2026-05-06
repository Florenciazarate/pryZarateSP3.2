using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace pryZarateSP3._2.UI
{
    internal static class GridStyle
    {
        private static readonly Color CLR_TEXT      = Color.FromArgb(15, 23, 42);
        private static readonly Color CLR_TEXT_SOFT = Color.FromArgb(100, 116, 139);
        private static readonly Color CLR_BORDER    = Color.FromArgb(226, 232, 240);
        private static readonly Color CLR_HEADER    = Color.FromArgb(241, 245, 249);
        private static readonly Color CLR_SELECT    = Color.FromArgb(238, 242, 255);
        private static readonly Color CLR_INDIGO    = Color.FromArgb(79, 70, 229);

        public static void Apply(Guna2DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.GridColor = CLR_BORDER;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.EnableHeadersVisualStyles = false;
            grid.Font = new Font("Segoe UI", 9.5F);

            grid.ColumnHeadersDefaultCellStyle.BackColor = CLR_HEADER;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = CLR_TEXT_SOFT;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersHeight = 40;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = CLR_TEXT;
            grid.DefaultCellStyle.SelectionBackColor = CLR_SELECT;
            grid.DefaultCellStyle.SelectionForeColor = CLR_INDIGO;
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.RowTemplate.Height = 40;

            grid.ThemeStyle.HeaderStyle.BackColor = CLR_HEADER;
            grid.ThemeStyle.HeaderStyle.ForeColor = CLR_TEXT_SOFT;
            grid.ThemeStyle.HeaderStyle.Height = 40;
            grid.ThemeStyle.RowsStyle.Height = 40;
            grid.ThemeStyle.RowsStyle.SelectionBackColor = CLR_SELECT;
            grid.ThemeStyle.RowsStyle.SelectionForeColor = CLR_INDIGO;
        }
    }
}
