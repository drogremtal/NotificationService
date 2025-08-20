
using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Data.Configuration;

namespace NotificationService.Infrastructure.Data
{
    public class NotificationDbContext(DbContextOptions<NotificationDbContext> option) : DbContext(option)
    {
        public DbSet<NotificationEntity> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        }
    }
}
