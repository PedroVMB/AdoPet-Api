using AdoPet_Api.Data;
using AdoPet_Api.Repositories;
using AdoPet_Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da conex�o com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("AdoPetConnection");
builder.Services.AddDbContext<AdoPetContext>(opts => opts.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adiciona servi�os ao cont�iner de inje��o de depend�ncia

// Configura��o do Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AdoPet-Api", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
});

// Registro dos servi�os no cont�iner de inje��o de depend�ncia
builder.Services.AddScoped<IPetRepository, PetService>();
builder.Services.AddScoped<IShelterRepository, ShelterService>();
builder.Services.AddScoped<ITutorRepository, TutorService>();
builder.Services.AddScoped<IAdoptionRepository, AdoptionService>();

// Adiciona o servi�o de autoriza��o
builder.Services.AddAuthorization();

// Adiciona o servi�o de controleadores
builder.Services.AddControllers();

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdoPet-Api v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
