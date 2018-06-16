using GMS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GMS.Data.EntityConfig
{
    public class FriendConfiguration : EntityTypeConfiguration<Friend>
    {
        public FriendConfiguration()
        {
            ToTable("Friends");

            HasKey(f => f.Id);

            Property(f => f.Fullname)
                 .HasMaxLength(150)
                .IsRequired();

            Property(f => f.ZipCode)
                .HasMaxLength(9)
                .IsRequired();

            Property(f => f.Address)
                .IsRequired();

            Property(f => f.City)
               .IsRequired();

            Property(f => f.Neighborhood)
                .HasMaxLength(50)
                .IsRequired();

            Property(f => f.AddressComplement)
                .HasMaxLength(150)
                .IsOptional();

            Property(f => f.Number)
                .IsRequired();

            Property(f => f.State)
                 .HasMaxLength(2)
                 .IsRequired();

            Property(f => f.Cellphone)
                .HasMaxLength(15)
                .IsRequired();

            Property(f => f.SocialNetwork)
                 .HasMaxLength(300)
                 .IsOptional();

            Property(f => f.Email)
                 .HasMaxLength(150)
                 .IsRequired();
        }
    }
}
