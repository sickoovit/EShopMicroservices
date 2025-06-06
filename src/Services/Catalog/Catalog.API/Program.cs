var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarterWithAssemblies(typeof(Program).Assembly);
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
})
.UseLightweightSessions(); 

var app = builder.Build();

app.MapCarter();
app.Run();