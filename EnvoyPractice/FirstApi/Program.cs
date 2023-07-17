using FirstApi.Data.DbContexts;
using FirstApi.Services;
using FirstApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<ReservationDbContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await PrepDb.PrepPopulationAsync(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
