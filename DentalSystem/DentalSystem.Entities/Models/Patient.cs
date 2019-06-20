using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentalSystem.Entities.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Sector { get; set; }

        public bool IsUrbanZone { get; set; }

        public bool HasInsurancePlan { get; set; }

        [StringLength(100)]
        public string NSS { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        public virtual ICollection<PatientHealth> PatientHealths { get; set; }
        public virtual ICollection<Odontogram> Odontograms { get; set; }
        public virtual ICollection<ActivityPerformed> ActivitiesPerformed { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}