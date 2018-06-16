using GMS.App.Interfaces;
using GMS.Data.Repositories;
using GMS.Domain.Entities;
using GMS.Domain.Interfaces;
using GMS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace GMS.App.Services
{
    public class LoansAppService : AppServiceBase<Loan>, ILoansAppService
    {
        private readonly ILoansService _loansService;

        public LoansAppService(ILoansService loansService)
            : base(loansService)
        {
            _loansService = loansService;
        }

        public IList<Loan> GetDetailedLoans()
        {
            return _loansService.GetDetailedLoans();
        }

        public int PendingCount()
        {
            return _loansService.PendingCount();
        }

        public int FinishedCount()
        {
            return _loansService.FinishedCount();
        }
    }
}
