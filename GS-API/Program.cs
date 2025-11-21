using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using GS_csharp.Data;
using GS_csharp.Repositories;
using GS_csharp.Services;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DE JSON E MVC ---
// Adiciona a correção para evitar loops infinitos de serialização (User -> Enrollment -> User)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Adiciona serviços básicos e documentação Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- 2. CONFIGURAÇÃO DO BANCO DE DADOS (SWITCHER) ---
var dbToUse = builder.Configuration.GetValue<string>("UseDatabase");
var connectionString = builder.Configuration.GetConnectionString("SupabaseDb");

if (dbToUse == "Supabase")
{
    // Usa o driver PostgreSQL para conectar ao Supabase (Produção)
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));
    
    Console.WriteLine("--- CONNECTED TO SUPABASE (POSTGRESQL) ---");
}
else
{
    // Usa o banco em memória (Desenvolvimento)
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("MeuBanco"));
    
    Console.WriteLine("--- CONNECTED TO INMEMORY DATABASE ---");
}
// -----------------------------------------------------

// --- 3. Injeção de Dependência ---

// Repositórios (Camada de Acesso a Dados)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ICompetenceRepository, CompetenceRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

// Serviços (Camada de Regras de Negócio)
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITrackService, TrackService>();
builder.Services.AddScoped<ICompetenceService, CompetenceService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
// -------------------------------------------------------------

var app = builder.Build();

// --- 4. PIPELINE DE REQUISIÇÃO HTTP ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();