using GMS.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.Domain.Interfaces.Services
{
    public interface ILoansService : IServiceBase<Loan>
    {
        IList<Loan> GetDetailedLoans();
        int PendingCount();
        int FinishedCount();
    }
}
