using API.Extensions;
using APP.Core.Interfaces;
using APP.Core.Options;
using APP.Core.Services;
using DB;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

services.AddScoped<AuthService>();
services.AddScoped<IAuthService, AuthService>();

services.AddControllers();
services.AddSwaggerGen();

services.AddApiAuthentication(configuration);
services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always,
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
