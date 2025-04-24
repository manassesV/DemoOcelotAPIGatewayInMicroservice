using Gateway.Middilewares;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile($"ocelot.json", optional: true);

builder.Services.AddOcelot().AddCacheManager(x =>
{
    x.WithDictionaryHandle();
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyHeader()
             .AllowAnyMethod()
             .AllowAnyOrigin();
        });
});





var app = builder.Build();

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<TokenCheckerMiddleware>();
app.UseMiddleware<InterceptionMiddileware>();

await app.UseOcelot();

app.Run();
