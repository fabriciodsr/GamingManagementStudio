using System;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GMS.Data.EntityConfig;
using GMS.Data.Identity;
using GMS.Domain.Entities;

namespace GMS.Data.Context
{ 
    public class GMSContext : DbContext
    {
        public GMSContext() : base("GMS") { }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey<int>(u => u.Id);
            modelBuilder.Entity<CustomUserRole>().ToTable("AspNetUserRoles").HasKey(ur => new { ur.RoleId, ur.UserId });
            modelBuilder.Entity<CustomUserLogin>().ToTable("AspNetUserLogins").HasKey<int>(ul => ul.UserId);
            modelBuilder.Entity<CustomUserClaim>().ToTable("AspNetUserClaims").HasKey<int>(uc => uc.Id);
            modelBuilder.Entity<CustomRole>().ToTable("AspNetRoles").HasKey<int>(r => r.Id);

            modelBuilder.Configurations.Add(new FriendConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new LoanConfiguration());
        }

        public static GMSContext Create()
        {
            return new GMSContext();
        }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("CreatedDate").IsModified = false;
                        entry.Property("ModifiedDate").CurrentValue = DateTime.Now;
                    }
                }
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
            catch (DbUpdateException ex)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} failed validation\n", ex.InnerException);
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
            catch (UpdateException ex)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} failed validation\n", ex.InnerException);
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
            catch (SqlException ex)
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0} failed validation\n", ex.InnerException);
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
        }
    }
}
