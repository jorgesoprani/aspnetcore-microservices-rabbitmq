using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbitMQ.Banking.Infrastructure.Data
{
    public class BankingDbContextFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankingDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankingDB;MultipleActiveResultSets=True;Uid=demo_user;Pwd=DemoUser*!");

            return new BankingDbContext(optionsBuilder.Options);
        }
    }
}
