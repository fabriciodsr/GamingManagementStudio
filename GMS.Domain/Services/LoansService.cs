using GMS.Domain.Entities;
using GMS.Domain.Interfaces;
using GMS.Domain.Interfaces.Repositories;
using GMS.Domain.Interfaces.Services;
using GMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GMS.App.Services
{
    public class LoansService : ServiceBase<Loan>, ILoansService
    {
        private readonly ILoansRepository _loansRepository;

        public LoansService(ILoansRepository loansRepository)
            : base(loansRepository)
        {
            _loansRepository = loansRepository;
        }

        public IList<Loan> GetDetailedLoans()
        {
            return _loansRepository.GetDetailedLoans();
        }

        public int PendingCount()
        {
            return _loansRepository.PendingCount();
        }

        public int FinishedCount()
        {
            return _loansRepository.FinishedCount();
        }
    }
}
