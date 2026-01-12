using System.Runtime;
using TournamentManager.Data;
using TournamentManager.Models.appsettings;
using TournamentManager.Repositories;
using TournamentManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DbManager>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<ITournamentLookupService, TournamentLookupService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.Configure<Appsettings>(builder.Configuration);

builder.Services.AddAuthentication("MyCookieAuth")
    .AddCookie("MyCookieAuth", options =>
    {
        options.Cookie.Name = "CookieName";
        options.LoginPath = "/Account/Login";   // Redirect if not logged in
        options.LogoutPath = "/Account/Logout"; // Optional
        options.AccessDeniedPath = "/Account/AccessDenied"; // For unauthorized roles
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
