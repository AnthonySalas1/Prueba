
using AdministradorAPI.DBContext;
using AdministradorAPI.Repository;
using AdministradorAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddDbContext<SigsContext>(options =>
    options.UseSqlServer("name=DefaultConnection"));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors(x =>
{
    x.AddPolicy("Administrador", builder =>
    {
        builder.WithOrigins("http://localhost:60406")
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();

}
app.UseCors("Administrador");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
