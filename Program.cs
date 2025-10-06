using apiwithdb.Repositories;
using apiwithdb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DI para Event (lista en memoria)
builder.Services.AddSingleton<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventService, EventService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

