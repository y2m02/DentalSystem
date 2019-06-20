using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentalSystem.Entities.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required]
        [StringLength(11)] 
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}