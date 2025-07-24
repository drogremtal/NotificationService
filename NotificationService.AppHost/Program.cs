var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.NotificationService_Api>("notificationservice");

builder.Build().Run();
