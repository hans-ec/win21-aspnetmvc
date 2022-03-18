using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repetition_forts;
using Repetition_forts.Models.Identity;
using Repetition_forts.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x => x.User.RequireUniqueEmail = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IUserClaimsPrincipalFactory<IdentityUser>, UserClaims>();
builder.Services.AddScoped<IProfileManager, ProfileManager>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.AccessDeniedPath = "/access-denied";
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
