using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PremiumCalculator.Repositories;
using PremiumCalculator.Services;
using PremiumCalculator.Strategy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddSingleton<IOccupationRepository, InMemoryOccupationRepository>();
builder.Services.AddSingleton<IRatingStrategyFactory, RatingStrategyFactory>();
builder.Services.AddScoped<IPremiumService, PremiumService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller=Premium}/{action=Index}/{id?}");
app.MapControllers();

app.Run();
