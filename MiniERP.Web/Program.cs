using Microsoft.AspNetCore.Authentication.Cookies;
using MiniERP.Web.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add HTTP Context Accessor
builder.Services.AddHttpContextAccessor();

// Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

// Add HttpClient
builder.Services.AddHttpClient<ApiService>();

// Add Custom Services
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<SalesInvoiceService>();
builder.Services.AddScoped<PurchaseInvoiceService>();
builder.Services.AddScoped<CariAccountService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PaymentService>();

var app = builder.Build();

// Configure culture for decimal formatting - use invariant culture for consistency
var cultureInfo = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
