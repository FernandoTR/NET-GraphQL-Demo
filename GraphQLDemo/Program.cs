using GraphQLDemo.Data;
using GraphQLDemo.Data.Interfaces;
using GraphQLDemo.Data.Repositories;
using GraphQLDemo.GraphQL.Mutations;
using GraphQLDemo.GraphQL.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configura la autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "tu_issuer",
            ValidAudience = "tu_audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("n4dBgAga0Il3W66tiu41Gv0wZrkgJg+DNBMoQIOFyno="))
        };
    });

// Agrega el servicio de controladores
builder.Services.AddControllers();

// Agrega el servicio de autenticación
builder.Services.AddAuthorization();

// Configura el servicio para EntityFramework
builder.Services.AddDbContext<EscuelaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega el repository
builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IInscripcioneRepository, InscripcioneRepository>();
builder.Services.AddScoped<IProfesoreRepository, ProfesoreRepository>();

// Configura GraphQL
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType(d => d.Name("Query"))
        .AddType<AlumnoQuery>()
        .AddType<CursoQuery>()
        .AddType<InscripcioneQuery>()
        .AddType<ProfesoreQuery>()
    .AddMutationType(d => d.Name("Mutation"))
        .AddType<AlumnoMutation>()
        .AddType<CursoMutation>()
        .AddType<InscripcioneMutation>()
        .AddType<ProfesoreMutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.

// Habilita la autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Mapea los controladores
app.MapControllers();

// Mapea GraphQL
app.MapGraphQL();

app.Run();
