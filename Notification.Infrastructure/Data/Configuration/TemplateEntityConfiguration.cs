using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain.Entities;

namespace NotificationService.Infrastructure.Data.Configuration
{
    public class TemplateEntityConfiguration : IEntityTypeConfiguration<TemplateEntity>
    {
        public void Configure(EntityTypeBuilder<TemplateEntity> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasIndex(q => q.Id).IsUnique();
            builder.Property(q => q.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(q => q.Description)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(q => q.Type).IsRequired();
            builder.Property(q => q.Template).IsRequired();

            builder.HasMany(q=>q.NotificationsCollection)
                .WithOne(q=>q.Template);
        }
    }
}
