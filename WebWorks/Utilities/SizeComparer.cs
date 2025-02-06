using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebWorks.Utilities
{
    public class SizeComparer : IComparer
    {
        private int columnIndex;
        private SortOrder sortOrder;

        public SizeComparer(int columnIndex, SortOrder sortOrder)
        {
            this.columnIndex = columnIndex;
            this.sortOrder = sortOrder;
        }

        public int Compare(object x, object y)
        {
            DataGridViewRow rowA = x as DataGridViewRow;
            DataGridViewRow rowB = y as DataGridViewRow;

            long sizeA = ParseSize(rowA.Cells[columnIndex].Value?.ToString());
            long sizeB = ParseSize(rowB.Cells[columnIndex].Value?.ToString());

            int result = sizeA.CompareTo(sizeB);

            return sortOrder == SortOrder.Descending ? -result : result;
        }

        private long ParseSize(string sizeText)
        {
            if (string.IsNullOrWhiteSpace(sizeText)) return 0;

            string[] parts = sizeText.Split(' ');
            if (parts.Length != 2) return 0;

            if (!double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                return 0;

            return parts[1].ToUpper() switch
            {
                "B" => (long)value,
                "KB" => (long)(value * 1024),
                "MB" => (long)(value * 1024 * 1024),
                "GB" => (long)(value * 1024 * 1024 * 1024),
                _ => 0
            };
        }
    }
}
