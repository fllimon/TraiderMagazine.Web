using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TraderMagazine.Web.Identity;
using TraderMagazine.Web.Identity.Models;
using TraderMagazine.Web.Identity.Models.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

var data = builder.Services.AddIdentityServer(option =>
{
    option.Events.RaiseErrorEvents = true;
    option.Events.RaiseSuccessEvents = true;
    option.Events.RaiseInformationEvents = true;
    option.Events.RaiseFailureEvents = true;
    option.EmitStaticAudienceClaim = true;

}).AddInMemoryIdentityResources(MetaData.IdentityResources)
.AddInMemoryApiScopes(MetaData.ApiScopes)
.AddInMemoryClients(MetaData.Clients)
.AddAspNetIdentity<ApplicationUser>();

data.AddDeveloperSigningCredential();

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var service = app.Services.CreateScope();
IDbInitializer init = service.ServiceProvider.GetService<IDbInitializer>();
init.Initialize();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


