using System;
using System.Collections.Generic;
using DentalSystem.Contract.Repositories;
using DentalSystem.Contract.Services;
using DentalSystem.Entities.Models;
using DentalSystem.Entities.Requests.Payment;
using DentalSystem.Entities.Results.Payment;

namespace DentalSystem.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public GetPaymentsByAccountReceivableIdResult
            GetPaymentsByAccountReceivableId(GetPaymentsByAccountReceivableIdRequest request)
        {
            var result = _paymentRepository.GetPaymentsByAccountReceivableId(request.AccountsReceivableId);
            var getPayments = request.Mapper.Map<List<GetPaymentsByAccountReceivableIdResultModel>>(result);

            var getPaymentsByAccountReceivableIdResult = new GetPaymentsByAccountReceivableIdResult
            {
                PaymentList = getPayments
            };

            return getPaymentsByAccountReceivableIdResult;
        }

        public void AddPayment(AddPaymentRequest request)
        {
            var payment = request.Mapper.Map<Payment>(request);
            _paymentRepository.AddPayment(payment);
        }

        public DeletePaymentResult DeletePayment(DeletePaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}