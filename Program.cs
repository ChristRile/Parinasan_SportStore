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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// to use the method (?) wako ka apas HHAHHAHAHAHA
app.UseStaticFiles();
app.MapControllerRoute("pagination","Products/Page{productPage}",new{ Controller = "Home", action = "Index"});
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// to match the http requests to the application features
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);
app.Run();
