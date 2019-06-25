using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Requests.Patient;
using DentalSystem.Entities.Requests.PatientHealth;
using DentalSystem.Entities.Results.Patient;
using DentalSystem.MapperConfiguration;

namespace DentalSystem
{
    public partial class Form1 : Form
    {
        private readonly IMapper _iMapper;
        private readonly IPatientService _patientService;

        private List<OdontogramTemplate> OdontogramTemplates;

        public Form1(IPatientService patientService)
        {
            var config = new AutoMapperConfiguration().Configure();
            _iMapper = config.CreateMapper();

            _patientService = patientService;
            InitializeComponent();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var request = new GetPatientByIdRequest
            {
                PatientId = 5
            };

            _patientService.GetPatientById(_iMapper, request);
            //tabControl1.SelectedIndex = 1;
        }

        private void BtnTeeth1Left_Click(object sender, EventArgs e)
        {
        }

        private void BtnTeeth1Center_Click(object sender, EventArgs e)
        {
            var button2 = OdontogramTemplates.FirstOrDefault(w => w.ButtonName == BtnTeeth1Center.Name);
            button2.ButtonColor = BtnTeeth1Center.BackColor.Name;

            foreach (var control in PnlTeeth1.Controls)
                if (control is Button)
                {
                    var button = (Button)control;

                    var btn = OdontogramTemplates.FirstOrDefault(w => w.ButtonName == button.Name);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Width = Width - 100;
            StartButtons();
            foreach (var control in panel1.Controls)
                if (control is Button)
                {
                    var button = (Button)control;

                    button.Click += delegate
                    {
                        if (button.BackColor == Color.Red)
                            button.BackColor = Color.Green;
                        else if (button.BackColor == Color.White)
                            button.BackColor = Color.Red;
                        else
                            button.BackColor = Color.White;
                    };
                }

            //var patients = ListPatients();
        }

        private void StartButtons()
        {
            OdontogramTemplates = new List<OdontogramTemplate>();

            string[] buttonPositions = { "Center", "Top", "Botton", "Right", "Left" };

            var j = 1;
            var k = 0;
            for (var i = 1; i <= 5; i++, k++)
            {
                OdontogramTemplates.Add(new OdontogramTemplate
                {
                    ButtonName = "BtnTeeth" + j + buttonPositions[k]
                });

                if (i % 5 == 0)
                {
                    j += 1;
                    k = 0;
                }
            }
        }

        //private IEnumerable<GetAllPatientsResult> ListPatients()
        //{
        //    var patients = _patientService.GetAllPatients(_iMapper);

        //    return patients;
        //}

        private void Form1_MaximumSizeChanged(object sender, EventArgs e)
        {
            MessageBox.Show("klk");
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //tabControl1.Width = Width - 100;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(800, 600);
            tabControl1.Width = Width - 100;
            pnlgrid.Width = tabControl1.Width - 100;
            //pnlgrid.Left = tabControl1.Width - 100;
            //pnlgrid.Left = tabControl1.Width - 100;

            pnlgrid.Location = new Point(
                tabControl1.ClientSize.Width / 2 - pnlgrid.Size.Width / 2,
                tabControl1.ClientSize.Height / 2 - pnlgrid.Size.Height / 5);
            pnlgrid.Anchor = AnchorStyles.None;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //tabControl1.Width = Width - 100;
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

public class OdontogramTemplate
{
    public string ButtonName { get; set; }
    public string ButtonColor { get; set; }
}