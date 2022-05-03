using TraiderMagazine.Web;
using TraiderMagazine.Web.Services;
using TraiderMagazine.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductServices, ProductService>();
MetaData.ApiUrl = builder.Configuration["Services:ProductAPI"];
builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = "Cookies";
    option.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(7))
.AddOpenIdConnect("oidc", option =>
{
    option.Authority = builder.Configuration["Services:IdentityAPI"];
    option.GetClaimsFromUserInfoEndpoint = true;
    option.ClientId = "TraderMagazine";
    option.ClientSecret = "secretKey1111";
    option.ResponseType = "code";

    option.TokenValidationParameters.NameClaimType = "name";
    option.TokenValidationParameters.RoleClaimType = "role";
    option.Scope.Add("TraderMagazine");
    option.SaveTokens = true;

});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
