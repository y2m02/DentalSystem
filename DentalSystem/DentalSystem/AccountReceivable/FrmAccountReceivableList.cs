﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.AccountsReceivable;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Results.AccountsReceivable;
using DentalSystem.VisitManagement;

namespace DentalSystem.AccountReceivable
{
    public partial class FrmAccountReceivableList : Form
    {
        private readonly IPaymentService _paymentService;
        private readonly IAccountReceivableService _accountReceivableService;
        private readonly IMapper _iMapper;
        public FrmAccountReceivableList(IAccountReceivableService accountReceivableService, IMapper iMapper, IPaymentService paymentService)
        {
            _accountReceivableService = accountReceivableService;
            _iMapper = iMapper;
            _paymentService = paymentService;
            InitializeComponent();
        }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public GetAllAccountsReceivableByPatientIdResult AccountReceivableList { get; set; }

        private void FrmAccountReceivableList_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                LblPatientName.Text = "Paciente: " + PatientName;

                ListReceivableByPatientId(AccountReceivableList);

                if (DgvAccountReceivableList.RowCount == 0) return;
                DgvAccountReceivableList.Rows[0].Selected = true;

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                ListPaymentsByAccountReceivableId(accountReceivableId);

                BtnAddPayment.Enabled = DgvAccountReceivableList.RowCount != 0;
                BtnDeletePayment.Enabled = DgvAccountReceivableList.RowCount != 0 && DgvPaymentList.RowCount != 0;

                var accounts = (List<GetAllAccountsReceivableByPatientIdResultModel>) DgvAccountReceivableList.DataSource;

                var totalPending = accounts.Sum(w => w.TotalPending);

                LblTotalPending.Text = $"Total pendiente: RD{totalPending:C0}";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                var totalPending = DgvAccountReceivableList.SelectedRows[0].Cells["TotalPending"].Value.ToString();

                if (Convert.ToInt32(totalPending) == 0)
                {
                    MessageBox.Show("Esta cuenta no tiene saldo pendiente", "Información", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);

                var totalPaid = Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["TotalPaid"].Value);

                Cursor.Current = Cursors.Default;

                var frm = new FrmAddPayment(_paymentService, _iMapper)
                {
                    AccountsReceivableId = accountReceivableId,
                    TotalPaid = totalPaid,
                    TotalPending = totalPending,
                    DialogResult = DialogResult.None
                };
                frm.ShowDialog();

                var rowIndex = DgvAccountReceivableList.SelectedRows[0].Index;

                var getAllAccountsReceivableByPatientIdRequest = new GetAllAccountsReceivableByPatientIdRequest
                {
                    PatientId = PatientId,
                    Mapper = _iMapper
                };

                var accountsReceivable =
                    _accountReceivableService.GetAllAccountsReceivableByPatientId(getAllAccountsReceivableByPatientIdRequest);
                
                ListReceivableByPatientId(accountsReceivable);

                if (DgvAccountReceivableList.RowCount == 0)
                {
                    DgvPaymentList.DataSource = null;
                    BtnAddPayment.Enabled = false;
                    BtnDeletePayment.Enabled = false;
                    return;
                }

                if (rowIndex == DgvAccountReceivableList.RowCount) rowIndex -= 1;
                DgvAccountReceivableList.Rows[rowIndex].Selected = true;

                var accountId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                ListPaymentsByAccountReceivableId(accountId);

                var accounts = (List<GetAllAccountsReceivableByPatientIdResultModel>)DgvAccountReceivableList.DataSource;
                var sumTotalPending = accounts.Sum(w => w.TotalPending);
                LblTotalPending.Text = $"Total pendiente: RD{sumTotalPending:C0}";
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnDeletePayment_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(DgvPaymentList.SelectedRows[0].Cells["PaymentId"].Value);

                var result = MessageBox.Show("¿Seguro que desea eliminar este registro?", "Información",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;

                var accountReceivableId =
                    Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
                var totalPaid = Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["TotalPaid"].Value);
                var paymentTotalPaid = Convert.ToInt32(DgvPaymentList.SelectedRows[0].Cells["AmountPaid"].Value);

                var updateTotalPaidRequest = new UpdateTotalPaidRequest
                {
                    AccountsReceivableId = accountReceivableId,
                    TotalPaid = totalPaid - paymentTotalPaid
                };

                var deletePatientRequest = new DeletePaymentRequest
                {
                    DeletedOn = DateTime.Now,
                    Mapper = _iMapper,
                    PaymentId = id,
                    UpdateTotalPaidRequest = updateTotalPaidRequest
                };

                _paymentService.DeletePayment(deletePatientRequest);

                var rowIndex = DgvAccountReceivableList.SelectedRows[0].Index;

                var getAllAccountsReceivableByPatientIdRequest = new GetAllAccountsReceivableByPatientIdRequest
                {
                    PatientId = PatientId,
                    Mapper = _iMapper
                };

                var accountsReceivable =
                    _accountReceivableService.GetAllAccountsReceivableByPatientId(getAllAccountsReceivableByPatientIdRequest);
                
                ListReceivableByPatientId(accountsReceivable);

                if (DgvAccountReceivableList.RowCount == 0)
                {
                    DgvPaymentList.DataSource = null;
                    return;
                }

                DgvAccountReceivableList.Rows[rowIndex].Selected = true;

                ListPaymentsByAccountReceivableId(accountReceivableId);

                var accounts = (List<GetAllAccountsReceivableByPatientIdResultModel>)DgvAccountReceivableList.DataSource;
                var sumTotalPending = accounts.Sum(w => w.TotalPending);
                LblTotalPending.Text = $"Total pendiente: RD{sumTotalPending:C0}";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ListReceivableByPatientId(GetAllAccountsReceivableByPatientIdResult result)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
        
                DgvAccountReceivableList.DataSource = result.AccountsReceivable;

                NameAccountReceivableGridHeader(DgvAccountReceivableList);

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void NameAccountReceivableGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["AccountsReceivableId"].Visible = false;
            dgv.Columns["VisitNumber"].HeaderText = "# visita";
            dgv.Columns["CreatedDate"].HeaderText = "Fecha";
            dgv.Columns["Total"].HeaderText = "Total";
            dgv.Columns["TotalPaid"].HeaderText = "Pagado";
            dgv.Columns["TotalPending"].HeaderText = "Pendiente";
        }

        private void ListPaymentsByAccountReceivableId(int accountReceivableId)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getPaymentsByAccountReceivableIdRequest = new GetPaymentsByAccountReceivableIdRequest
                {
                    Mapper = _iMapper,
                    AccountsReceivableId = accountReceivableId
                };

                var payments =
                    _paymentService.GetPaymentsByAccountReceivableId(getPaymentsByAccountReceivableIdRequest);
                DgvPaymentList.DataSource = payments.PaymentList;

                NamePaymentGridHeader(DgvPaymentList);

                BtnDeletePayment.Enabled = false;
                if (DgvPaymentList.RowCount == 0) return;
                BtnDeletePayment.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Hubo un error durante el proceso: " + ex.Message, "Información", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static void NamePaymentGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["PaymentId"].Visible = false;
            dgv.Columns["AmountPaid"].HeaderText = "Abono";
            dgv.Columns["PaymentDate"].HeaderText = "Fecha";
        }

        private void DgvAccountReceivableList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var accountReceivableId =
                Convert.ToInt32(DgvAccountReceivableList.SelectedRows[0].Cells["AccountsReceivableId"].Value);
            ListPaymentsByAccountReceivableId(accountReceivableId);
        }
    }
}