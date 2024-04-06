using Microsoft.EntityFrameworkCore;
using ScoreBoard.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IJoueurRepository, BDJoueurRepository>();
builder.Services.AddScoped<IJeuRepository, BDJeuRepository>();
builder.Services.AddDbContext<CatalogueJeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:CatalogueJeuDbContextConnection"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

InitialiseurDB.Seed(app);

app.Run();
