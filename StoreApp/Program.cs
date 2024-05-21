using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;
using StoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
//Session
builder.Services.ConfigureSession();

builder.Services.ConfigureRepositoryRegistirion();

builder.Services.ConfigureServiceRegistirion();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureRouting(); //url küçük harflere çeviren extension

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
//session
app.UseSession();
 
app.UseRouting();
app.ConfigureLocalization(); //Uygulamaya yerel özellikler içeren yapýyý kullanýyoruz.
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
}
    
);

app.ConfigureAndCheckMigration(); //Application Extension
app.ConfigureDefaultAdminUser();
app.Run();
