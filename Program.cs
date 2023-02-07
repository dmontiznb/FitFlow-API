using FitFlow;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Allowed", policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyOrigin();

    });
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

startup.Configure(app, builder.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Allowed");

app.UseAuthorization();

app.MapControllers();

app.Run();
