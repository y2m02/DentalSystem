using System;
using System.Windows.Forms;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Context;
using DentalSystem.Patient;
using DentalSystem.Repositories.Repositories;
using DentalSystem.Services.Services;
using Unity;

namespace DentalSystem
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IPatientService, PatientService>();
            container.RegisterType<IPatientRepository, PatientRepository>();

            container.RegisterType<IActivityPerformedService, ActivityPerformedService>();
            container.RegisterType<IActivityPerformedRepository, ActivityPerformedRepository>();

            container.RegisterType<IVisitService, VisitService>();
            container.RegisterType<IVisitRepository, VisitRepository>();

            container.RegisterType<IInvoiceDetailService, InvoiceDetailService>();
            container.RegisterType<IInvoiceDetailRepository, InvoiceDetailRepository>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FrmPatientList>());
        }
    }
}