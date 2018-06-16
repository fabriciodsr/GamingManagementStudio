using GMS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GMS.Data.EntityConfig
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            ToTable("Games");

            HasKey(g => g.Id);

            Property(g => g.Name)
                 .HasMaxLength(150)
                 .IsRequired();

            Property(g => g.Genre)
                 .IsOptional();

            Property(g => g.Platform)
                 .IsOptional();

            Property(g => g.Developer)
                .IsOptional();
        }
    }
}
