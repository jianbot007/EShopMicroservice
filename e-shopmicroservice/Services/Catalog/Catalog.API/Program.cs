using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(
    config => { config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(
    opts =>{
        opts.Connection(builder.Configuration.GetConnectionString("Default")!);
       
    }).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

app.Run();
