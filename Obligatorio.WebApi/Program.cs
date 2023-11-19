using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositoriosEntity;
using LogicaAplicacion.CasosUso.Configuracion;
using LogicaAplicacion.CasosUso.Ecosistemas;
using LogicaAplicacion.InterfacesCasosUso.Configuracion;
using LogicaAplicacion.InterfacesCasosUso.Ecosistemas;
using Microsoft.EntityFrameworkCore;
using Usuarios.InterfacesRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddScoped<IRepositorioEcosistema, RepositorioEcosistema>();
builder.Services.AddScoped<RepositorioUsuarioProyecto>();
builder.Services.AddScoped<IRepositorioAmenaza,RepositorioAmenaza>();
builder.Services.AddScoped<IRepositorioEstadoConservacion,RepositorioEstadosConservacion>();
builder.Services.AddScoped<IRepositorioConfiguracion, RepositorioConfiguracion>();
builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
builder.Services.AddScoped<IRepositorioEspecie, RepositorioEspecie>();
builder.Services.AddScoped<IGetEcosistemas,GetEcosistemas>();
builder.Services.AddScoped<IAltaEcosistema, AltaEcosistema>();
builder.Services.AddScoped<IGetEcosistemaById, GetEcosistemaById>();
builder.Services.AddScoped<IModificarConfiguracion, ModificarConfiguracion>();
builder.Services.AddScoped<IBorrarEcosistema, BorrarEcosistema>();
builder.Services.AddDbContext<ObligatorioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringConexion")));

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

app.Run();
