using DotNetWorkspace.SignalR.Server.Hubs;

const string policyName = "SignalRPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, policy =>
    {
        policy
            .WithOrigins("https://localhost:7240")
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