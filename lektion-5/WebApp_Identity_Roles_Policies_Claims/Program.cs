using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp_Identity_Roles_Policies_Claims.Data;
using WebApp_Identity_Roles_Policies_Claims.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IAddressManager, AddressManager>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/auth/signin";
});

builder.Services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaims>();

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admins", p => p.RequireRole("admin"));
    x.AddPolicy("AuthenticatedUsers", p => p.RequireRole("admin", "user"));
});






builder.Services.AddControllersWithViews();

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

app.UseAuthentication();    // Vem är du?   inloggning
app.UseAuthorization();     // Vad är du berättigad till?       Roller, Nycklar/ApiKeys

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
