using Confluent.Kafka;
using FluentValidation;
using NotificationService;
using NotificationService.Application.Interface;
using NotificationService.Application.Services;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Email;
using NotificationService.Infrastructure.Logger;
using NotificationService.Infrastructure.Messaging;
using NotificationService.Mapper;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.OpenSearch;
using AutoRegisterTemplateVersion = Serilog.Sinks.OpenSearch.AutoRegisterTemplateVersion;
using CertificateValidations = OpenSearch.Net.CertificateValidations;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();

Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));


builder.AddServiceDefaults();

// Add services to the container.


var username= builder.Configuration.GetSection("OpenSearchConfig:Username").Value;
var password  = builder.Configuration.GetSection("OpenSearchConfig:Password").Value;

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.OpenSearch(new OpenSearchSinkOptions(new Uri("https://localhost:9200"))
    {
        AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.OSv1,
        MinimumLogEventLevel = LogEventLevel.Verbose,
        TypeName = "_doc",
        InlineFields = false,
        ModifyConnectionSettings = x =>
            x.BasicAuthentication(username, password)
                .ServerCertificateValidationCallback(CertificateValidations.AllowAll)
                .ServerCertificateValidationCallback((o, certificate, chain, errors) => true),
        IndexFormat = "notification-service-{0:yyyy.MM.dd}",
    })
    .CreateLogger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => { },typeof(TemplateProfiles));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddScoped<INotificationService, NotificationAppService>();

builder.AddNpgsqlDbContext<NotificationDbContext>("notificationDb");

builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("SmtpConfig"));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<MigrationHostedService>();
builder.Services.AddScoped<INotificationProcessor, NotificationProcessor>();
builder.Services.AddScoped<INotificationTemplateService, NotificationTemplateService>();

builder.Services.AddScoped<IMessageBrokerProducer, KafkaProducer>();

builder.AddKafkaProducer<string, string>("kafka");
builder.AddKafkaConsumer<string, string>("kafka", options =>
{
    options.Config.GroupId = "notification";
    options.Config.AutoOffsetReset = AutoOffsetReset.Earliest;
    options.Config.EnableAutoCommit = false;
});


builder.Services.AddHostedService<KafkaMessageConsumer>();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

var app = builder.Build();



app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
