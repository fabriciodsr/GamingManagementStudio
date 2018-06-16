using GMS.Domain.Entities;
using System.Collections.Generic;

namespace GMS.Domain.Interfaces.Repositories
{
    public interface ILoansRepository : IRepositoryBase<Loan>
    {
        IList<Loan> GetDetailedLoans();
        int PendingCount();
        int FinishedCount();
    }
}
