using System;
using AutoMapper;
using DentalSystem.Entities.Requests.Visit;

namespace DentalSystem.Entities.Requests.AccountsReceivable
{
    public class AddAccountsReceivableRequest
    {
        public int AccountsReceivableId { get; set; }
        public int PatientId { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public DateTime CreatedDate { get; set; }
        public IMapper Mapper { get; set; }
        public SetVisitAsBilledRequest SetVisitAsBilledRequest { get; set; }
    }
}