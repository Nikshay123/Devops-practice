var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in ALL environments, including Production
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // Ensures Swagger is available at "/swagger"
});

// Remove HTTPS redirection to avoid conflicts
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
