using DataAccess.Data;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//GAGAN CONNECTION
//var connectionString = builder.Configuration.GetConnectionString("LocalConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//ANITA CONNECTION
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//AUTO PROVIDED
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//	builder.Configuration.GetConnectionString("LocalConnection")
//	));

//CUSTOM CBTD
//builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//My custom
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.Configure<IdentityOptions>(options => { 

    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength  = 5;
    options.Password.RequiredUniqueChars = 1;
});
builder.Services.AddScoped<UnitOfWork>();
// SIMPLE AUTH
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
//    options =>
//    {
//        options.LoginPath = "/Logins/Login";
//    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();


app.Run();

