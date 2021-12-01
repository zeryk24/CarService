using CarService.BL.Installers;
using CarService.DAL.Installers;
using CarService.DAL.Repositories.Generic;
using CarService.DAL.Repositories.Interfaces.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.DalInstall(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
builder.Services.BlInstall();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
