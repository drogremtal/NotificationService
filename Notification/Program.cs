using NotificationService;
using NotificationService.Application.Interface;
using NotificationService.Application.Services;
using NotificationService.Infrastructure;
using NotificationService.Infrastructure.Data;
using NotificationService.Infrastructure.Email;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotificationService, NotificationAppService>();

builder.AddNpgsqlDbContext<NotificationDbContext>("notificationDb");

builder.Services.Configure<SmtpConfig>(builder.Configuration.GetSection("SmtpConfig"));
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<MigrationHostedService>();



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
