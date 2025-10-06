using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Application.Interface;
using NotificationService.Infrastructure.Email;

using NotificationService.Infrastructure.Interface;
using NotificationService.Infrastructure.Messaging;
using NotificationService.Infrastructure.Repository;


namespace NotificationService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
      
            //services.Configure<SmtpConfig>(configuration.GetSection("SmtpConfig"));
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();


            services.AddSingleton<ISmtpEmailService, SmtpEmailService>();
            //services.AddSingleton<ISmtpEmailService, FakeEmailService>();
     

            return services;
        }
    }
}
