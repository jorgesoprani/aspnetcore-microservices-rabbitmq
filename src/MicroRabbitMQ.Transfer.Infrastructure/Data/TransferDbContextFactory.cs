using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MicroRabbitMQ.Transfer.Infrastructure.Data
{
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TransferDB;MultipleActiveResultSets=True;Uid=demo_user;Pwd=DemoUser*!");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}
