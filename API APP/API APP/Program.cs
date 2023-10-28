using API_APP.DAL;
using API_APP.Domain.Interfaces;
using API_APP.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//crea el contexto de la BD a la hora de correr la API
//funciones anonimas (x=> x... ) Arrow functions - Lambda functions
builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//por cada interfaz agregar aqui el servicio

//builder.Services.AddTransient;
//builder.Services.AddSingleton;
builder.Services.AddScoped<ICountryService, CountryService>();  //se crea en cada ejecucion
builder.Services.AddScoped<IStateService, StateService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
