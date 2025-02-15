var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable serving static files (Swagger assets)
app.UseStaticFiles();

// ✅ Enable Swagger in both Development and Production
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Ensures Swagger loads at "/swagger"
    });
}

// Disable HTTPS redirection in Production
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// Ensure the app listens on HTTP in Docker
app.Urls.Add("http://*:80");

app.UseAuthorization();
app.MapControllers();
app.Run();
