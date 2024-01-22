using BeHeroes.CodeOps.Infrastructure.Kafka;
using Heimdall.Templates.Dotnet.Microservice.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<KafkaConsumerService>();

var host = builder.Build();

host.Run();
