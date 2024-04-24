using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CatalogueJeuDbContextConnection") ?? throw new InvalidOperationException("Connection string 'CatalogueJeuDbContextConnection' not found.");
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJoueurRepository, BDJoueurRepository>();
builder.Services.AddScoped<IJeuRepository, BDJeuRepository>();
builder.Services.AddDbContext<CatalogueJeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogueJeuDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CatalogueJeuDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

InitialiseurDB.Seed(app);

app.Run();
