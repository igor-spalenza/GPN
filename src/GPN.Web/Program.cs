using GPN.Application.Interfaces;
using GPN.Application.Services;
using GPN.Domain.Interfaces.Repositories;
using GPN.Infrastructure.Data.Context;
using GPN.Infrastructure.Data.Repositories;
using GPN.Web.Data;
using GPN.Web.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SQLite;
using GPN.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddScoped<ProjectDataContext>(provider => { return new ProjectDataContext(connectionString); });

// Add services to the container.
builder.Services.AddScoped<IUserStore<IdentityUser>, CustomUserStore>();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructureServices(connectionString);

builder.Services.AddScoped<IdentitySchemaInitializer>(provider =>
    new IdentitySchemaInitializer(connectionString));

// Registrar o DatabaseInitializer
builder.Services.AddScoped<DatabaseInitializer>(provider =>
    new DatabaseInitializer(connectionString));

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbIdentityInit = scope.ServiceProvider.GetRequiredService<IdentitySchemaInitializer>();
    dbIdentityInit.Initialize();
    var dbInit = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
    dbInit.Initialize();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
