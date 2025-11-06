using BuildingBlocks.Behaviors;

var builder = WebApplication.CreateBuilder(args);


//Add Service to Container
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR( cfg =>
{
    cfg.RegisterServicesFromAssembly(assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
});


var app = builder.Build();

//Configure the HTTP request pipeline.

app.MapCarter();


app.Run();
