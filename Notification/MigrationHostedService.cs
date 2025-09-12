using Microsoft.EntityFrameworkCore;
using NotificationService.Infrastructure.Data;

namespace NotificationService
{
    public class MigrationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public MigrationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateAsyncScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<NotificationDbContext>();
                await context.Database.MigrateAsync(cancellationToken: cancellationToken);
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)=> Task.CompletedTask;
      
    }
}
