var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in both Development and Production
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Disable HTTPS redirection in Docker (Production mode)
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// Ensure the app listens on HTTP in Docker
app.Urls.Add("http://*:80");

app.UseAuthorization();
app.MapControllers();
app.Run();
