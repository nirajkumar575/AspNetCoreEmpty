using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreEmpty.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.;

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSingleton<ApplicationUser>();

builder.Services.AddCors(options => //Method 1 to add policy
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://example.com", "http://www.contoso.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddCors(option=> //Method 2 to add policy
{
    option.AddPolicy("MyPolicy",
        a => a.WithOrigins("Domain info"));
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

app.UseAuthorization();

app.UseCors();//Method 1 to use policy
app.UseCors("MyPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();//Added by Me

app.Run();
