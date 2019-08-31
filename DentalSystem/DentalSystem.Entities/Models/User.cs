using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentalSystem.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }

        [StringLength(50)] public string UserName { get; set; }

        [StringLength(50)] public string Password { get; set; }

        [Required] [StringLength(100)] public string FullName { get; set; }

        [StringLength(11)] public string IdentificationCard { get; set; }
        [StringLength(1)] public string Gender { get; set; }

        [StringLength(10)] public string PhoneNumber { get; set; }

        [StringLength(300)] public string Address { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ActivityPerformed> ActivitiesPerformed { get; set; }
    }
}