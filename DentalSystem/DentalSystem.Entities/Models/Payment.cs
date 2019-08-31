using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentalSystem.Entities.Models
{
    public class Payment
    {
        [Key] public int PaymentId { get; set; }
        [ForeignKey("AccountsReceivable")] public int AccountsReceivableId { get; set; }
   public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Month { get; set; }
        public DateTime? DeletedOn { get; set; }
        public virtual AccountsReceivable AccountsReceivable { get; set; }
    }
}