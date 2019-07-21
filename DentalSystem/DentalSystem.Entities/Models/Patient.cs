using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentalSystem.Entities.Models
{
    public class Patient
    {
        [Key] public int PatientId { get; set; }

        [Required] [StringLength(100)] public string FullName { get; set; }
        [StringLength(15)] public string IdentificationCard { get; set; }
        public int? Age { get; set; }

        [StringLength(1)] public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }
        [StringLength(10)] public string PhoneNumber { get; set; }
        [StringLength(200)] public string Address { get; set; }
        [StringLength(100)] public string Sector { get; set; }
        public bool? IsUrbanZone { get; set; }
        public bool? HasInsurancePlan { get; set; }

        // ReSharper disable once InconsistentNaming
        [StringLength(100)] public string NSS { get; set; }
        [Required] public DateTime AdmissionDate { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual PatientHealth PatientHealth { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual List<AccountsReceivable> AccountReceivables { get; set; }
    }
}