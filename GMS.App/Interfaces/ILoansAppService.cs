using GMS.Domain.Entities;
using System.Collections.Generic;

namespace GMS.App.Interfaces
{
    public interface ILoansAppService : IAppServiceBase<Loan>
    {
        IList<Loan> GetDetailedLoans();
        int PendingCount();
        int FinishedCount();
    }
}
