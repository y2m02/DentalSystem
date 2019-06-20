using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Rol")]
        public int RolId { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        public bool IsActived { get; set; }

        [StringLength(50)]
        public string DeletedBy { get; set; }

        public DateTime DeletedOn { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual ICollection<ActivityPerformed> ActivitiesPerformed { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}