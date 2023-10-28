

using DotNetWorkspace.SignalR.WebAPI.Hubs;

const string policyName = "SignalRPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, policy => 
    {
        policy
            .WithOrigins("https://localhost:5088", "https://localhost:7190")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddSignalR();


var app = builder.Build();

// UseCors must be called before MapHub.
app.UseCors(policyName);  

app.MapHub<ChatHub>("/chat-hub");

app.Run();
