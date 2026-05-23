using Common;
using Microsoft.EntityFrameworkCore;
using ProfileService.Data;
using ProfileService.DTOs;
using ProfileService.Middleware;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddKeyCloakAuthentication();
await builder.UseWolverineWithRabbitMqAsync(opts =>
{
    opts.ApplicationAssembly = typeof(Program).Assembly;
});

builder.AddNpgsqlDbContext<ProfileDbContext>("profileDb");
// Add services to the container.

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseMiddleware<UserProfileCreationMiddleware>();

app.MapGet("/profiles/me",async(ClaimsPrincipal user,ProfileDbContext db)=>
{
    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
    if (userId is null) return Results.Unauthorized();

    var profile = await db.UserProfiles.FindAsync(userId);
    return profile is null ? Results.NotFound() : Results.Ok(profile);
}).RequireAuthorization();

app.MapGet("/profiles/batch", async (string ids, ProfileDbContext db) =>
{
    var list = ids.Split(",",StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();

    var rows = await db.UserProfiles
    .Where(x => list.Contains(x.Id))
    .Select(x => new ProfileSummaryDto(x.Id,x.DisplayName,x.Reputation)).ToListAsync();

    return Results.Ok(rows);
});

// Configure the HTTP request pipeline.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<ProfileDbContext>();
    await context.Database.MigrateAsync();
}
catch (Exception e)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(e, "An error occurred while migrating the database.");
}

app.Run();
