var builder = DistributedApplication.CreateBuilder(args);


var postges= builder.AddPostgres("postrges")
    .WithPgAdmin(n=>n.WithHostPort(5000));
var postgresDb = postges.AddDatabase("notificationDb");




builder.AddProject<Projects.NotificationService>("notification").WithReference(postgresDb);

builder.Build().Run();
