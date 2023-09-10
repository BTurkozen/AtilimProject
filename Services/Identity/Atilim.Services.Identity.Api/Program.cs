using Atilim.Services.Identity.Api.Helpers.Extentions;
using Atilim.Services.Identity.Application.Interfaces;
using Atilim.Services.Identity.Domain.Entities;
using Atilim.Services.Identity.Infrastructure.Services;
using Atilim.Shared.Settings.Concrates;
using Atilim.Shared.Settings.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var tokenConfiguration = builder.Configuration.GetSection(nameof(TokenSettings));

builder.Services.Configure<TokenSettings>(tokenConfiguration);

builder.Services.AddSingleton<ITokenSettings>(options =>
{
    return options.GetRequiredService<IOptions<TokenSettings>>().Value;
});

builder.Services.AddCustomAuthentication(tokenConfiguration.Get<TokenSettings>());

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var provider = scope.ServiceProvider;

var roleManager = provider.GetRequiredService<RoleManager<UserRole>>();

if (roleManager.Roles.Any() is false)
{
    await roleManager.CreateAsync(new UserRole { Id = Guid.NewGuid().ToString(), Name = "admin", ConcurrencyStamp = Guid.NewGuid().ToString() });
}

var userManager = provider.GetRequiredService<UserManager<User>>();

if (userManager.Users.Any() is false)
{
    var user = new User()
    { Id = Guid.NewGuid().ToString(), UserName = "Bturk", Email = "Bturk@blabla.com" };

    await userManager.CreateAsync(user, "Password_*12");

    await userManager.AddToRoleAsync(user, "admin");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
