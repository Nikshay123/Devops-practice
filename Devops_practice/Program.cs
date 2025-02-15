var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Enable serving static files (Swagger assets)
app.UseStaticFiles();

// ✅ Always enable Swagger (for debugging inside Docker)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // Ensures Swagger loads at "/swagger"
});

// ✅ Ensure the app listens on HTTP inside Docker
app.Urls.Add("http://+:80");

app.UseAuthorization();
app.MapControllers();
app.Run();
