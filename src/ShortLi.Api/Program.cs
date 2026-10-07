

using ShortLi.Application;
using ShortLi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var jwtSection = builder.Configuration.GetSection("JwtSettings");
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
Console.WriteLine($"Base path: {builder.Environment.ContentRootPath}");

Console.WriteLine(
    $"Jwt section exists: {builder.Configuration.GetSection("JwtSettings").Exists()}"
);

Console.WriteLine(
    $"Secret: {builder.Configuration["JwtSettings:Secret"]}"
);
Console.WriteLine($"Secret: {jwtSection["Secret"]}");
Console.WriteLine($"Expiry: {jwtSection["ExpiryMinutes"]}");
Console.WriteLine($"Issuer: {jwtSection["Issuer"]}");
Console.WriteLine($"Audience: {jwtSection["Audience"]}");
    builder.Services.AddApplication();
    builder.Services.AddInfrastructre(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
