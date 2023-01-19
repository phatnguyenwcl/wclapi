using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using WCLWebAPI.Client.IServicesInterface;
using WCLWebAPI.Client.Services;
using WCLWebAPI.Server.ViewModels.System.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.AccessDeniedPath = "/User/Forbidden";
    });

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

builder.Services.AddControllersWithViews().AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


// Add services to the container.
//builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IUserApiClientServiceInterface, UserApiClientService>();
builder.Services.AddTransient<IRoleApiClientServiceInterface, RoleApiClientService>();
builder.Services.AddTransient<IDepartmentApiClientServiceInterface, DepartmentApiClientService>();
builder.Services.AddTransient<IEmployeeApiClientServiceInterface, EmployeeApiClientService>();
builder.Services.AddTransient<ITimeSheetApiClientServiceInterface, TimeSheetApiClientService>();

builder.Services.AddRazorPages();

var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default", 
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
