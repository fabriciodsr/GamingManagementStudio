using GMS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GMS.Data.EntityConfig
{
    public class LoanConfiguration : EntityTypeConfiguration<Loan>
    {
        public LoanConfiguration()
        {
            ToTable("Loans");

            Property(l => l.LoanDate)
               .IsRequired();

            Property(l => l.DeliveredDate)
              .IsOptional();
        }
    }
}
