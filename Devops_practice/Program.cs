var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable serving static files (Swagger assets)
app.UseStaticFiles();

// ✅ Always enable Swagger (Production + Development)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger loads at "/"
});

// 🚀 Remove HTTPS redirection (not needed inside Docker)
app.UseAuthorization();
app.MapControllers();
app.Run();
