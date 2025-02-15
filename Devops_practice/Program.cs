var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// **Ensure Swagger works in production**
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "swagger"; // Ensures Swagger is available at "/swagger"
});

// **Serve Static Files for Swagger**
app.UseStaticFiles();  // <-- ADD THIS LINE

// Remove HTTPS redirection
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
