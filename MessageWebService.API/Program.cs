using MessageWebService.API.DAL;
using MessageWebService.API.Hubs;
using MessageWebService.API.Models;
using Microsoft.Extensions.Logging;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MessageRepository>(new MessageRepository(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddLogging(logging => logging.AddConsole());
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Message API V1");
});

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<MessageHub>("/messagesHub");
});

app.Run();
