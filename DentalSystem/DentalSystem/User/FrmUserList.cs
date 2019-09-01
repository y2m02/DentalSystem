using System;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.User;
using DentalSystem.Utility;

namespace DentalSystem.User
{
    public partial class FrmEmployeeList : Form
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public FrmEmployeeList(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            InitializeComponent();
        }

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            ListUsers("");
            if (DgvEmployeeList.RowCount>0)
            {
                DgvEmployeeList.Rows[0].Selected = true;
            }
        }

        private void ListUsers(string filter)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var getAllUserRequest = new GetAllUserRequest
                {
                    Mapper = _mapper,
                    SearchParameter = filter
                };

                var users = _userService.GetAllUser(getAllUserRequest);
                DgvEmployeeList.DataSource = users.UserList;
                NameGridHeader(DgvEmployeeList);

                BtnModify.Enabled = BtnDelete.Enabled = DgvEmployeeList.RowCount > 0;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
            }
        }

        private static void NameGridHeader(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns["UserId"].Visible = false;
            dgv.Columns["FullName"].HeaderText = "Nombre";
            dgv.Columns["IdentificationCard"].HeaderText = "Cédula";
            dgv.Columns["Gender"].HeaderText = "Género";
            dgv.Columns["PhoneNumber"].HeaderText = "Teléfono";
            dgv.Columns["Address"].HeaderText = "Dirección";
            dgv.Columns["Address"].Visible = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ListUsers(TxtSearch.Text.Trim());
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.None;
            TxtSearch.Clear();
            ListUsers("");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(DgvEmployeeList.SelectedRows[0].Cells["UserId"].Value);
             
                var result = CustomMessage.QuestionMessage("¿Seguro que desea eliminar este registro?");

                if (result != DialogResult.Yes) return;

                Cursor.Current = Cursors.WaitCursor;
                var deleteUserRequest = new DeleteUserRequest
                {
                    UserId = id,
                    DeletedOn = DateTime.Now,
                    Mapper = _mapper
                };
                _userService.DeleteUser(deleteUserRequest);

                ListUsers("");

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                CustomMessage.ErrorMessage($"Hubo un error durante el proceso: {ex.Message}");
                    
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FrmUserMaintenance(_mapper, _userService)
            {
                IsModify = false,
                Text = "Agregar empleado"
            };

            frm.ShowDialog();
            ListUsers("");
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            var userId = Convert.ToInt32(DgvEmployeeList.SelectedRows[0]?.Cells["UserId"].Value);
            var fullName = DgvEmployeeList.SelectedRows[0]?.Cells["FullName"].Value;
            var identificationCard = DgvEmployeeList.SelectedRows[0]?.Cells["IdentificationCard"].Value;
            var gender = DgvEmployeeList.SelectedRows[0]?.Cells["Gender"].Value;
            var phoneNumber = DgvEmployeeList.SelectedRows[0]?.Cells["PhoneNumber"].Value;
            var address = DgvEmployeeList.SelectedRows[0]?.Cells["Address"].Value;

            var frm = new FrmUserMaintenance(_mapper, _userService)
            {
                IsModify = true,
                Text = "Modificar empleado",
                UserId = userId,
                FullName = fullName?.ToString(),
                IdentificationCard = identificationCard?.ToString(),
                Gender = gender?.ToString(),
                PhoneNumber = phoneNumber?.ToString(),
                Address = address?.ToString()
            };

            frm.ShowDialog();
            ListUsers("");
        }
    }
}