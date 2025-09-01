using Confluent.Kafka;
using FluentValidation;
using NotificationService;
using NotificationService.Application.Interface;
using NotificationService.Application.Services;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Email;
using NotificationService.Mapper;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

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

builder.Services.AddScoped<INotificationTemplateService, NotificationTemplateService>();

builder.AddKafkaProducer<string, string>("kafka");
builder.AddKafkaConsumer<string, string>("kafka", options =>
{
    options.Config.GroupId = "my-consumer-group";
    options.Config.AutoOffsetReset = AutoOffsetReset.Earliest;
    options.Config.EnableAutoCommit = false;
});

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
