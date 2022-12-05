using Microsoft.EntityFrameworkCore;
using ReStore.BackEnd.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var service = builder.Services;

// Add services to the container.
service.AddControllers();
service.AddEndpointsApiExplorer();
service.AddSwaggerGen();
service.AddDbContext<StoreContext>(opt => {
    opt.UseSqlite(configuration.GetConnectionString("DefaultCOnnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
var logger = app.Logger;

try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "Problem migrating data");
}
finally
{
    scope.Dispose();
}

app.Run();
