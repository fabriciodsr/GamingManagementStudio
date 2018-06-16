using System.Collections.Generic;
using GMS.Domain.Entities;
using GMS.Domain.Interfaces;
using System.Data.Entity;
using System.Linq;
using GMS.Domain.Interfaces.Repositories;

namespace GMS.Data.Repositories
{
    public class LoansRepository : RepositoryBase<Loan>, ILoansRepository
    {
        public IList<Loan> GetDetailedLoans()
        {
            return Db.Loans.Include(x => x.Friend).Include(x => x.Game).Where(x => !x.Deleted).OrderBy(x => x.DeliveredDate).ToList();
        }

        public int PendingCount()
        {
            return Db.Loans.Where(x => x.DeliveredDate == null).Count();
        }

        public int FinishedCount()
        {
            return Db.Loans.Where(x => x.DeliveredDate != null).Count();
        }
    }
}
