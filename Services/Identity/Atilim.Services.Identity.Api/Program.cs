using Atilim.Services.Identity.Api.Helpers.Extentions;
using Atilim.Services.Identity.Application;
using Atilim.Services.Identity.Application.Interfaces;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Infrastructure;
using Atilim.Services.Identity.Infrastructure.Seeds;
using Atilim.Services.Identity.Infrastructure.Services;
using Atilim.Shared.Settings.Concrates;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth", new OpenApiSecurityScheme
    {
        Description = "Standart Authorization header using the Bearer Scheme(\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 0;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

}).AddEntityFrameworkStores<IdentityContext>()
.AddDefaultTokenProviders();

var tokenConfiguration = builder.Configuration.GetSection(nameof(TokenSettings));

builder.Services.Configure<TokenSettings>(tokenConfiguration);

builder.Services.AddSingleton<ITokenSettings>(options =>
{
    return options.GetRequiredService<IOptions<TokenSettings>>().Value;
});

builder.Services.AddCustomAuthentication(tokenConfiguration.Get<TokenSettings>());

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Configuration
       .SetBasePath(builder.Environment.ContentRootPath)
       .AddJsonFile("appsettings.json", optional: false)
       .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();

    DataSeeding.Seed(app);
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
