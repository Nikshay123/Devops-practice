var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in Production
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // Ensures Swagger is available at "/swagger"
});

// Enable static file serving (IMPORTANT for Swagger UI)
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();
app.Run();
