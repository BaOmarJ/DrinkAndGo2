using DrinkAndGo2.Data.Interfaces;
using DrinkAndGo2.Data.Mocks;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration.Json;
using DrinkAndGo2.Data;
using Microsoft.EntityFrameworkCore;
using DrinkAndGo2.Data.Repositories;
using DrinkAndGo2.Data.Models;
using DrinkAndGo.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add application db context configuration
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("" +
    "DefaultConnectionString")));

// Add services to the container.
builder.Services.AddControllersWithViews();
// register trhe services
//builder.Services.AddTransient<IDrinkRepository, MockDrinkRepository>();
//builder.Services.AddTransient<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddTransient<IDrinkRepository, DrinkRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp=>ShoppingCart.GetCart(sp));
builder.Services.AddMemoryCache();
builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(name: "categoryFilter",
pattern: "Drink/{action}/{category?}",
defaults: new { controller = "Drink", action = "List" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseMvc(routes =>
//{
//    routes.MapRoute(name: "categoryFilter", template: "Drink/{action}/{category?}"), Defaults: new { Controller="Drink", Action="List" };
//    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
//});

DbInitializer.Seed(app);
app.Run();
