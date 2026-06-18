using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeknikServis.Api.Data;
using TeknikServis.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Controller desteğini açar.
builder.Services.AddControllers();

// OpenAPI belgesini üretir.
builder.Services.AddOpenApi();

// User Secrets içindeki SQL bağlantı bilgisini okur.
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "DefaultConnection bağlantı bilgisi bulunamadı.");

// Entity Framework'e SQL Server kullanacağını söyler.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Kullanıcı kayıt ve giriş altyapısını ekler.
// Kullanıcı bilgileri SQL Server üzerinde tutulur.
builder.Services
    .AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Yetkilendirme sistemini açar.
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Teknik Servis API v1");
    });
}

app.UseHttpsRedirection();

// Önce kullanıcının kim olduğunu belirler.
app.UseAuthentication();

// Sonra kullanıcının ilgili işlemi yapmaya yetkisi var mı kontrol eder.
app.UseAuthorization();

app.MapControllers();

// Hazır kullanıcı kayıt ve giriş adreslerini oluşturur.
app.MapGroup("/api/auth")
    .MapIdentityApi<ApplicationUser>();

app.Run();