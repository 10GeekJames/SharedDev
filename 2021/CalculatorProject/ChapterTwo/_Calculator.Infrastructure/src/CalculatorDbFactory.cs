using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Calculator.Infrastructure
{
    public class CalculatorDbFactory : IDesignTimeDbContextFactory<CalculatorDbContext>
    {
        public CalculatorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>();
            optionsBuilder.UseSqlServer(System.Environment.GetEnvironmentVariable("Calculator2ConnectionStringsPrimary"), b => b.MigrationsAssembly("Calculator.Api"));
            return new CalculatorDbContext(optionsBuilder.Options);
        }

    }
}
