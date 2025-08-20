using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Data.Configuration
{
    public class NotificationConfiguration:IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {

            builder.HasKey(n => n.Id);
            builder.Property(n => n.Title).HasMaxLength(150).IsRequired();
            builder.Property(n=>n.Message).HasMaxLength(500).IsRequired();
            builder.Property(n => n.Recipient).HasMaxLength(100).IsRequired();
            builder.Property(n => n.Type);
            builder.Property(n => n.CreatedAt).HasColumnType("timestamp(6)");
            builder.Property(n => n.SentAt).HasColumnType("timestamp(6)");
            builder.Property(n => n.Metadata);



        }
    }
}
