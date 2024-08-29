var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register carter
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
var app = builder.Build();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    
}).UseLightweightSessions();

// Configure the HTTP request pipeline.
app.MapCarter();
app.Run();
