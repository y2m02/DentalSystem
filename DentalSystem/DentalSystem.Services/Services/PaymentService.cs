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
        private readonly IAccountReceivableRepository _accountReceivableRepository;

        public PaymentService(IPaymentRepository paymentRepository, IAccountReceivableRepository accountReceivableRepository)
        {
            _paymentRepository = paymentRepository;
            _accountReceivableRepository = accountReceivableRepository;
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

        public GetAllPaymentForReportResult GetAllPaymentForReport(GetAllPaymentForReportRequest request)
        {
            var result = _paymentRepository.GetAllPaymentForReport(request.From, request.To);
            var getPayments = request.Mapper.Map<List<GetAllPaymentForReportResultModel>>(result);

            var getAllPaymentForReportResult = new GetAllPaymentForReportResult
            {
                PaymentList = getPayments
            };

            return getAllPaymentForReportResult;
        }

        public void AddPayment(AddPaymentRequest request)
        {
            var payment = request.Mapper.Map<Payment>(request);
            _paymentRepository.AddPayment(payment);

            var accountReceivable = request.Mapper.Map<AccountsReceivable>(request.UpdateTotalPaidRequest);
            _accountReceivableRepository.UpdateTotalPaid(accountReceivable);
        }

        public void DeletePayment(DeletePaymentRequest request)
        {
            var payment = request.Mapper.Map<Payment>(request);
            _paymentRepository.DeletePayment(payment);

            var accountReceivable = request.Mapper.Map<AccountsReceivable>(request.UpdateTotalPaidRequest);
            _accountReceivableRepository.UpdateTotalPaid(accountReceivable);
        }
    }
}