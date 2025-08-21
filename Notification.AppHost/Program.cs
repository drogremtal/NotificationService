var builder = DistributedApplication.CreateBuilder(args);


var postges= builder.AddPostgres("postrges")
    .WithPgAdmin(n=>n.WithHostPort(5000));
var postgresDb = postges.AddDatabase("notificationDb");

var kafka = builder.AddKafka("kafka")
    .WithKafkaUI(kafka=>kafka.WithHostPort(9100));


builder.AddProject<Projects.NotificationService>("notification")
    .WithReference(postgresDb)
    .WithReference(kafka)
    .WaitFor(postgresDb)
    .WaitFor(kafka);

builder.Build().Run();
