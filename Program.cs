using BibliotecaAPI.Data;
using BibliotecaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<EmprestimoRepository>();

var app = builder.Build();
app.MapControllers();

app.Run();