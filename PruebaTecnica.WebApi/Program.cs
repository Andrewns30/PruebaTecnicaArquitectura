using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.DataAccess;
using PruebaTecnica.DataAccess.Repository;
using PruebaTecnica.Helpers.AutoMapping;
using PruebaTecnica.Helpers.Extensions;
using PruebaTecnica.Helpers.LoggerManager;
using PruebaTecnica.Models.Helpers;
using PruebaTecnica.Services;
using PruebaTecnica.Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = builder.Configuration;
builder.Services.AddScoped<DbContext, ProyectoContext>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
builder.Services.AddSwaggerCustom(xmlPath, "Prueba técnica");
builder.Services.AddCorsCoustoms(Configuration);
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

#region Transient
builder.Services.AddTransient(typeof(IDataRepository<>), typeof(DataRepository<>));
builder.Services.AddTransient<ILog, Log>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
#endregion

builder.Services.AddAutoMapper(c => c.AddProfile<AutoMappingHelper>(), typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(c => c.SerializeAsV2 = false);
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.Json", "Prueba técnica v1"));

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

