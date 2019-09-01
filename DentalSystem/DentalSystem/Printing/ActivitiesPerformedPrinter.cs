using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace DentalSystem.Printing
{
    public class ActivitiesPerformedPrinter
    {
        private readonly PrintingModel _printingModel;

        public ActivitiesPerformedPrinter(PrintingModel printingModel)
        {
            _printingModel = printingModel;
        }
        public void BillPrinting()
        {
            var dt = new DataTable();

            dt.Columns.Add("ActivityPerformed");
            dt.Columns.Add("Section");
            dt.Columns.Add("Price");

            foreach (var item in _printingModel.ItemsToBill)
            {
                var row = dt.NewRow();

                row["ActivityPerformed"] = item.ActivityPerformed;
                row["Section"] = item.Section;
                row["Price"] = item.Price;

                dt.Rows.Add(row);
            }

            PrintInvoice(dt);
        }

        public void PrintInvoice(DataTable dtActivitiesPerformed)
        {
            //var printDialog = new PrintDialog();
            //var dr = printDialog.ShowDialog();

            //if (dr != DialogResult.OK) return;

            using (var rpt = new RptActivitiesPerformed())
            {
                if (rpt.ReportDefinition.ReportObjects["LblVisitDate"] is TextObject visitDate)
                    visitDate.Text = _printingModel.VisitDate.ToString("dd/M/yy");
                if (rpt.ReportDefinition.ReportObjects["LblVisitNumber"] is TextObject visitNumber)
                    visitNumber.Text = _printingModel.VisitNumber;
                if (rpt.ReportDefinition.ReportObjects["LblTotal"] is TextObject total)
                    total.Text = $"{_printingModel.Total:C}"; 
                if (rpt.ReportDefinition.ReportObjects["LblPaid"] is TextObject paid) paid.Text = $"{_printingModel.Paid:C}";
                if (rpt.ReportDefinition.ReportObjects["LblPending"] is TextObject pending)
                    pending.Text = $"{_printingModel.Pending:C}";

                rpt.SetDataSource(dtActivitiesPerformed);
                var crReportDocument = rpt;


                //Get the Copy times
                //int nCopy = printDialog.PrinterSettings.Copies;

                ////Get the number of Start Page
                //var sPage = printDialog.PrinterSettings.FromPage;

                ////Get the number of End Page
                //var ePage = printDialog.PrinterSettings.ToPage;

                //var printName = printDialog.PrinterSettings.PrinterName;
                //var isCollated = printDialog.PrinterSettings.Collate;
                var printerSettings = new PrinterSettings();
                crReportDocument.PrintOptions.PrinterName = printerSettings.PrinterName;

                //Start the printing process.  Provide details of the print job
              
            crReportDocument.PrintToPrinter(1, false, 0, 0);
            }
        }
    }
}