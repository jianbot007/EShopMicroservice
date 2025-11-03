var builder = WebApplication.CreateBuilder(args);


//Add Service to Container


var app = builder.Build();

//Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.Run();
