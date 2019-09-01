using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using CrystalDecisions.CrystalReports.Engine;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Reports.AccountReceivable;
using DentalSystem.Reports.Income;
using DentalSystem.Utility;

namespace DentalSystem
{
    public partial class FrmDateRange : Form
    {
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IMapper _iMapper;
        private readonly bool _isAccountReceivableReport;
        private readonly IPaymentService _paymentService;
        private string title;

        public FrmDateRange(bool isAccountReceivableReport, IMapper iMapper,
            IAccountReceivableService accountReceivableService, IPaymentService paymentService)
        {
            _isAccountReceivableReport = isAccountReceivableReport;
            _iMapper = iMapper;
            _accountReceivableService = accountReceivableService;
            _paymentService = paymentService;
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChkDateRange_CheckedChanged(object sender, EventArgs e)
        {
            DtpFrom.Enabled = DtpTo.Enabled = ChkDateRange.CheckState == CheckState.Checked;
        }

        private void BtnShowReport_Click(object sender, EventArgs e)
        {
            if (ChkDateRange.Checked && DtpFrom.Value.Date > DtpTo.Value.Date)
            {
                CustomMessage.ExclamationMessage("La fecha \"Desde\" no puede ser mayor que la fecha \"Hasta\"");

                DtpFrom.Value = DtpTo.Value = DateTime.Now;
                return;
            }

            try
            {
                ReportDocument rpt;
                if (_isAccountReceivableReport)
                    rpt = ShowAccountReceivableReport();
                else
                    rpt = ShowIncomeReport();

                if (rpt == null)
                {
                    Cursor.Current = Cursors.Default;
                    CustomMessage.InformationMessage("No hay información para general el reporte");
                    return;
                }

                var frmReport = new FrmAccountReceivableReport
                {
                    Text = title,
                    CrvAccountReceivable = { ReportSource = rpt }
                };
                frmReport.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
            }
        }

        private RptAccountReceivable ShowAccountReceivableReport()
        {
            Cursor.Current = Cursors.WaitCursor;
            title = "Cuentas por cobrar";

            var getAllAccountReceivableForReportRequest = new GetAllAccountReceivableForReportRequest
            {
                Mapper = _iMapper,
                IncludeDate = ChkDateRange.Checked,
                From = DtpFrom.Value.Date,
                To = DtpTo.Value.Date.AddDays(1)
            };

            var accountsReceivable =
                _accountReceivableService.GetAllAccountReceivableForReport(getAllAccountReceivableForReportRequest);

            if (!accountsReceivable.AccountsReceivable.Any()) return null;

            var dt = new DataTable();

            dt.Columns.Add("VisitNumber");
            dt.Columns.Add("Total");
            dt.Columns.Add("TotalPaid");
            dt.Columns.Add("TotalPending");
            dt.Columns.Add("PatientName");
            dt.Columns.Add("CreatedDate");

            dt.Columns["VisitNumber"].DataType = typeof(int);
            dt.Columns["Total"].DataType = typeof(decimal);
            dt.Columns["TotalPaid"].DataType = typeof(decimal);
            dt.Columns["TotalPending"].DataType = typeof(decimal);
            dt.Columns["PatientName"].DataType = typeof(string);
            dt.Columns["CreatedDate"].DataType = typeof(DateTime);

            foreach (var item in accountsReceivable.AccountsReceivable)
            {
                var row = dt.NewRow();

                row["VisitNumber"] = item.VisitNumber;
                row["Total"] = item.Total;
                row["TotalPaid"] = item.TotalPaid;
                row["TotalPending"] = item.TotalPending;
                row["PatientName"] = item.PatientName;
                row["CreatedDate"] = item.CreatedDate;

                dt.Rows.Add(row);
            }

            var rpt = new RptAccountReceivable();

            rpt.SetDataSource(dt);
            Cursor.Current = Cursors.Default;
            return rpt;
        }

        private RptIncome ShowIncomeReport()
        {
            Cursor.Current = Cursors.WaitCursor;

            title = "Ingresos";

            var getAllPaymentForReportRequest = new GetAllPaymentForReportRequest
            {
                Mapper = _iMapper,
                IncludeDate = ChkDateRange.Checked,
                From = DtpFrom.Value.Date,
                To = DtpTo.Value.Date.AddDays(1)
            };

            var accountsReceivable =
                _paymentService.GetAllPaymentForReport(getAllPaymentForReportRequest);

            if (!accountsReceivable.PaymentList.Any()) return null;

            var dt = new DataTable();

            dt.Columns.Add("Month");
            dt.Columns.Add("MonthDescription");
            dt.Columns.Add("AmountPaid");
            dt.Columns.Add("PaymentDate");
            dt.Columns.Add("PatientName");

            dt.Columns["Month"].DataType = typeof(int);
            dt.Columns["MonthDescription"].DataType = typeof(string);
            dt.Columns["PatientName"].DataType = typeof(string);
            dt.Columns["AmountPaid"].DataType = typeof(decimal);
            dt.Columns["PaymentDate"].DataType = typeof(DateTime);

            foreach (var item in accountsReceivable.PaymentList)
            {
                var row = dt.NewRow();

                row["Month"] = item.Month;
                row["MonthDescription"] = item.MonthDescription;
                row["AmountPaid"] = item.AmountPaid;
                row["PaymentDate"] = item.PaymentDate;
                row["PatientName"] = item.PatientName;

                dt.Rows.Add(row);
            }

            var rpt = new RptIncome();

            rpt.SetDataSource(dt);
            Cursor.Current = Cursors.Default;
            return rpt;
        }

        private void FrmDateRange_Load(object sender, EventArgs e)
        {
            PnlButtons.Location = new Point(
                ClientSize.Width / 2 - PnlButtons.Size.Width / 2,
                PnlButtons.Location.Y);
        }
    }
}