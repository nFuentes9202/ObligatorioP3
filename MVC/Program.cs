using Dominio.Entidades.ValueObjects.Ecosistema;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using LogicaAccesoDatos.RepositoriosEntity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<RepositorioEcosistema>();
builder.Services.AddScoped<RepositorioUsuario>();
builder.Services.AddScoped<RepositorioAmenaza>();
builder.Services.AddScoped<RepositorioEstadosConservacion>();
builder.Services.AddScoped<RepositorioConfiguracion>();
builder.Services.AddScoped<RepositorioPais>();
builder.Services.AddScoped<RepositorioEspecie>();
builder.Services.AddDbContext<ObligatorioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringConexion")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

EnsureDatabaseSeeded(app);

app.Run();

void EnsureDatabaseSeeded(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ObligatorioContext>();
        SeedData(context);
    }
}

void SeedData(ObligatorioContext context)
{
    if (!context.Ecosistemas.Any())
    {
        var ecosistema1 = new Ecosistema
        {
            Nombre = "Selva Amazónica",
            AreaMetrosCuadrados = 5500000,
            Descripcion = "La selva amazónica es la selva tropical más extensa del mundo.",
            Coordenadas = new Coordenadas((decimal)-3.4653, (decimal)-62.2159),
            Imagen = new Imagen("Que lindo es el amazonas","Selva amazónica", "AmazonasPrueba.jpg"),
            EstadoConservacionId = 1 
        };

        var ecosistema2 = new Ecosistema
        {
            Nombre = "Sahara",
            AreaMetrosCuadrados = 9200000,
            Descripcion = "El Sahara es el desierto cálido más grande del mundo.",
            Coordenadas = new Coordenadas((decimal)23.4162, (decimal)25.6628),
            Imagen = new Imagen("Qué lindo es el sahara","Desierto del Sahara", "SaharaPrueba.jpg"),
            EstadoConservacionId = 1 
        };

        context.Ecosistemas.AddRange(ecosistema1, ecosistema2);
        context.SaveChanges();
    }
}