using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Vozni_Park.Helpers
{
    public class TablePrinter
    {
        private DataGridView dataGridView;
        private PrintDocument printDocument;
        private int currentRow;
        private int numberOfColumnsToPrint;
        private const int ColumnWidth = 90;
        private const int RowHeight = 25;
        private const int RowHeightWithText = 40;

        public TablePrinter(DataGridView dgv, int numberOfColumns)
        {
            dataGridView = dgv;
            numberOfColumnsToPrint = Math.Min(numberOfColumns, dgv.Columns.Count - 1); // Isključujemo ID kolonu
            printDocument = new PrintDocument();
            PageSettings pageSettings = new PageSettings();

            if (numberOfColumns > 7)
            {
                pageSettings.Landscape = true;
            }
            else
            {
                pageSettings.Landscape = false;
            }
            printDocument.DefaultPageSettings = pageSettings;
            printDocument.PrintPage += new PrintPageEventHandler(PrintPage);
        }

        public void PrintTable()
        {
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDocument
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                currentRow = 0;
                printDocument.Print();
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            int leftMargin = 40;
            int topMargin = e.MarginBounds.Top;
            Font font = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black);

            int totalVehicles = dataGridView.Rows.Count;
            e.Graphics.DrawString($"Ukupno vozila: {totalVehicles}", font, brush, leftMargin, topMargin - 20);

            int xPos = leftMargin;
            int yPos = topMargin;

            e.Graphics.DrawLine(pen, leftMargin, yPos, xPos + (numberOfColumnsToPrint * ColumnWidth) + ColumnWidth / 2, yPos);

            StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            // Štampanje zaglavlja rednog broja
            RectangleF indexRect = new RectangleF(xPos, yPos, ColumnWidth / 2, RowHeight * 2);
            e.Graphics.DrawString("r.b.", font, brush, indexRect, format);
            xPos += ColumnWidth / 2;
            e.Graphics.DrawLine(pen, xPos, yPos, xPos, yPos + RowHeight * 2); // Linija između rednog broja i prve kolone

            // Štampanje naziva kolona, preskačući ID kolonu (prva kolona)
            for (int colIndex = 1; colIndex <= numberOfColumnsToPrint; colIndex++)
            {
                RectangleF cellRect = new RectangleF(xPos, yPos, ColumnWidth, RowHeight * 2);
                e.Graphics.DrawString(dataGridView.Columns[colIndex].HeaderText, font, brush, cellRect, format);
                xPos += ColumnWidth;
                e.Graphics.DrawLine(pen, xPos, yPos, xPos, yPos + RowHeight * 2);
            }

            yPos += RowHeight * 2;
            xPos = leftMargin;
            e.Graphics.DrawLine(pen, leftMargin, yPos, xPos + (numberOfColumnsToPrint * ColumnWidth) + ColumnWidth / 2, yPos);

            // Štampanje redova sa podacima
            while (currentRow < dataGridView.Rows.Count)
            {
                xPos = leftMargin;
                int rowHeight = RowHeight * 2;

                // Štampanje rednog broja
                RectangleF indexCellRect = new RectangleF(xPos, yPos, ColumnWidth / 2, rowHeight);
                e.Graphics.DrawString((currentRow + 1).ToString(), font, brush, indexCellRect, format);
                xPos += ColumnWidth / 2;
                e.Graphics.DrawLine(pen, xPos, yPos, xPos, yPos + rowHeight); // Linija između rednog broja i prve kolone

                // Štampanje podataka, preskačući ID kolonu
                for (int colIndex = 1; colIndex <= numberOfColumnsToPrint; colIndex++)
                {
                    string value = dataGridView.Rows[currentRow].Cells[colIndex].Value?.ToString() ?? "";
                    RectangleF cellRect = new RectangleF(xPos, yPos, ColumnWidth, rowHeight);
                    e.Graphics.DrawString(value, font, brush, cellRect, format);
                    xPos += ColumnWidth;
                    e.Graphics.DrawLine(pen, xPos, yPos, xPos, yPos + rowHeight);
                }

                yPos += rowHeight;
                currentRow++;

                if (yPos + RowHeight * 2 > e.MarginBounds.Bottom)
                {
                    e.Graphics.DrawLine(pen, leftMargin, topMargin, leftMargin, yPos);
                    e.Graphics.DrawLine(pen, leftMargin, yPos, xPos, yPos);
                    e.HasMorePages = true;
                    return;
                }

                e.Graphics.DrawLine(pen, leftMargin, yPos, xPos, yPos);
            }

            e.Graphics.DrawLine(pen, leftMargin, topMargin, leftMargin, yPos);
            e.HasMorePages = false;
        }
    }
}
