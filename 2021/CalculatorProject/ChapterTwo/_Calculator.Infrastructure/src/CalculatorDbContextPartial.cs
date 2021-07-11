using System.Security.Cryptography;
// This file is now under code-gen control, do not touch, will be regenerated frequenly
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;
namespace Calculator.Infrastructure
{
    public partial class CalculatorDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { optionsBuilder.UseSqlServer(System.Environment.GetEnvironmentVariable("Calculator2ConnectionStringsPrimary"), b => b.MigrationsAssembly("Calculator.Api")); }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetForeignKeys())
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<IndividualInBusiness>()
            .HasKey(rs => new { rs.IndividualId, rs.BusinessId });

        }
        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.UtcNow;
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.CurrentValues.Properties.Select(rs => rs.Name).Contains("CreatedOn"))
                {

                    if (entry.Property("CreatedOn").Metadata.ClrType == typeof(DateTime))
                    {
                        if ((DateTime)entry.Property("CreatedOn").CurrentValue == new DateTime())
                        {
                            entry.Property("CreatedOn").CurrentValue = saveTime;
                        }
                    }
                    else if (entry.Property("CreatedOn").Metadata.ClrType == typeof(DateTime?))
                    {
                        if ((DateTime?)entry.Property("CreatedOn").CurrentValue == null || (DateTime?)entry.Property("CreatedOn").CurrentValue == new DateTime())
                        {
                            entry.Property("CreatedOn").CurrentValue = saveTime;
                        }
                    }

                }
                if (entry.CurrentValues.Properties.Select(rs => rs.Name).Contains("LastUpdatedOn"))
                {
                    if ((DateTime)entry.Property("LastUpdatedOn").CurrentValue == new DateTime())
                    {
                        entry.Property("LastUpdatedOn").CurrentValue = saveTime;
                    }
                }

                if (entry.CurrentValues.Properties.Select(rs => rs.Name).Contains("WebSafeKey"))
                {
                    if (entry.Property("WebSafeKey").CurrentValue == null)
                    {
                        entry.Property("WebSafeKey").CurrentValue = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 7);
                    }
                }
            }
            return base.SaveChanges();
        }

        private static readonly Regex _keysRegex = new Regex("^(PK|FK|IX)_", RegexOptions.Compiled);
    }
}
