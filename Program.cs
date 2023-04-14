using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Parinasan_SportStore.Models;

var builder = WebApplication.CreateBuilder(args);

// merges the controller components 
builder.Services.AddControllersWithViews();

// 
builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

// to create a service when each http requests get their own repository request
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute("catpage","{category}/Page{productPage:int}",
new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page", "Page{productPage:int}",
new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("category", "{category}",
new { Controller = "Home", action = "Index", productPage = 1 });

app.MapControllerRoute("pagination","Products/Page{productPage}",
new { Controller = "Home", action = "Index", productPage = 1 });

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// to match the http requests to the application features
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);
app.Run();
