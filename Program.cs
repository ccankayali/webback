using Microsoft.Extensions.Options;
using MongoDB.Driver;
using YourNamespace.Models;
using YourNamespace.Repositories;
using YourNamespace.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDB Ayarlarını Ekle
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDB")
);

// MongoDB Client'ı ve Repository'i Ekle
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// MongoDB Bağlantısı ve Kullanılacak Veritabanını Ayarla
builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return client.GetDatabase(settings.DatabaseName);
});

// Repository ve Service'leri ekle
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Auth Service ve Repository Ekle
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Order Service ve Repository Ekle
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Controller'ları ve Swagger'ı Ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS'u Ekle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Frontend URL'si
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();

// Swagger ve Diğer Middleware'ler
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Middleware'i Kullan
app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
