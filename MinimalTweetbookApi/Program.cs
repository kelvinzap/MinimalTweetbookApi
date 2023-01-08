using Microsoft.AspNetCore.Authorization;
using MinimalTweetbookApi.Installers;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.InstallServicesInAssembly(configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal Tweetbook Api"));

app.Run();