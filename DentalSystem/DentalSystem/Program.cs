using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Repositories.Repositories;
using DentalSystem.Services.Services;
using System;
using System.Windows.Forms;
using DentalSystem.Patient;
using Unity;

namespace DentalSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IPatientService, PatientService>();
            container.RegisterType<IPatientRepository, PatientRepository>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FrmPatientList>());
        }
    }
}