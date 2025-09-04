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
            builder.Property(q => q.Subject);  
            builder.Property(q => q.Template).IsRequired();
            builder.Property(q => q.Enabled);
            builder.Property(q => q.CreatedDate).HasColumnType("timestamp(6)");
            builder.Property(q => q.UpdatedDate).HasColumnType("timestamp(6)");
            builder.Property(q => q.AuthtorCreated);
            builder.Property(q => q.AuthtorUpdated);


            builder.HasMany(q => q.NotificationsCollection)
                .WithOne(q => q.Template);


            builder.HasData(
                new List<TemplateEntity>()
                {
                     new TemplateEntity()
                     {
                         Id = Guid.Parse("a65865e1-a1c0-42cf-b7fd-b7c9480f236a"),
                         Name = "Начальный шаблон",
                         Description = "Описание начльного шаблона",
                         Type = "Authorization",
                         Subject = "Добро пожаловать!",
                         Enabled = true,
                         CreatedDate = DateTime.Parse("01.01.2025"),
                         UpdatedDate = null,
                         AuthtorCreated = "Test",
                         AuthtorUpdated = String.Empty,
                         Template = @"<html> 
                            <body>
                            <h1>Добро пожаловать, {{UserName}} !</h1>
                        <p>Ваш email: {{Email}}</p>
                        <p>Дата регистрации: {{RegistrationDate}}</p>
                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>
                    </body>
                </html>"
                     }  ,
                     new TemplateEntity()
                     {
                         Id = Guid.Parse("b0669b35-8efc-4eb5-bf1c-702eae5e91ae"),
                         Name = "Начальный шаблон",
                         Description = "Описание начльного шаблона",
                         Type = "Authorization",
                         Subject = "Добро пожаловать!",
                         Enabled = true,
                         CreatedDate = DateTime.Parse("01.01.2025"),
                         UpdatedDate = null,
                         AuthtorCreated = "Test",
                         AuthtorUpdated = String.Empty,
                         Template = @"<html> 
                            <body>
                            <h1>Добро пожаловать, {{UserName}} !</h1>
                        <p>Ваш email: {{Email}}</p>
                        <p>Дата регистрации: {{RegistrationDate}}</p>
                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>
                    </body>
                </html>"
                     },
                     new TemplateEntity()
                     {
                         Id = Guid.Parse("fd17ed09-6805-48dc-9f1f-ad89146979a9"),
                         Name = "Начальный шаблон",
                         Description = "Описание начльного шаблона",
                         Type = "Authorization",
                         Subject = "Добро пожаловать!",
                         Enabled = true,
                         CreatedDate = DateTime.Parse("01.01.2025"),
                         UpdatedDate = null,
                         AuthtorCreated = "Test",
                         AuthtorUpdated = String.Empty,
                         Template = @"<html> 
                            <body>
                            <h1>Добро пожаловать, {{UserName}} !</h1>
                        <p>Ваш email: {{Email}}</p>
                        <p>Дата регистрации: {{RegistrationDate}}</p>
                        <p><a href='{{ActivationLink}}'>Активировать аккаунт</a></p>
                    </body>
                </html>"
                     }
                }
                );

        }

    }
}
