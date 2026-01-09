// Dosyanın en üstüne 3 using ekle - VeriKatmani, Iskatmani.Services, EntityFrameworkCore
using InternetCafe.VeriKatmani;
using InternetCafe.Iskatmani.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i DI'a kaydet - AddDbContext kullan, UseSqlServer ile "DefaultConnection" bağla
builder.Services.AddDbContext<KafedbContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// KullaniciService'i DI'a kaydet - AddScoped kullan
builder.Services.AddScoped<KullaniciService>();



// BilgisayarServices'i DI'a kaydet - AddScoped kullan
builder.Services.AddScoped<BilgisayarServices>();

// OturumService'i DI'a kaydet - AddScoped kullan
builder.Services.AddScoped<OturumService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
