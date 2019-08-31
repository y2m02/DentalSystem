using System.ComponentModel.DataAnnotations;

namespace DentalSystem.Entities.Models
{
    public class AdminPassword
    {
        [Key] public int AdminPasswordId { get; set; }
        [StringLength(50)] public string Password { get; set; }
    }
}