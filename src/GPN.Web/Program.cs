using GPN.Application.Interfaces;
using GPN.Application.Services;
using GPN.Domain.Interfaces.Repositories;
using GPN.Web.Data;
using GPN.Web.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Data.SQLite;
using GPN.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

SQLitePCL.Batteries.Init();
string dbPath = Path.Combine(AppContext.BaseDirectory, "gpn_spalenza_dev.db");

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddInfrastructureServices(connectionString);

builder.Services.AddScoped<IdentitySchemaInitializer>(provider =>
    new IdentitySchemaInitializer(connectionString));

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();
