using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using StudentManagementSystem.Membership;
using StudentManagementSystem.Membership.BusinessObjects;
using StudentManagementSystem.Membership.Contexts;
using StudentManagementSystem.Membership.Entities;
using StudentManagementSystem.Membership.Seeds;
using StudentManagementSystem.Membership.Services;
using StudentManagementSystem.Web;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SMSDbConnection");
var migrationAssemblyName = typeof(Program).Assembly.FullName;

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new WebModule())
    .RegisterModule(new MembershipModule(connectionString, migrationAssemblyName));

});

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(migrationAssemblyName)));

builder.Services.AddDbContext<MembershipDbContext>(options =>
                options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(migrationAssemblyName)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
//options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services
    .AddIdentity<ApplicationUser, Role>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<UserManager>()
    .AddRoleManager<RoleManager>()
    .AddSignInManager<SignInManager>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Denied");
        options.LogoutPath = new PathString("/Account/Logout");
        options.Cookie.Name = "";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdmin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new SuperAdminRequirement());
    });

    options.AddPolicy("Teacher", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new TeacherRequirement());
    });

    options.AddPolicy("Student", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new StudentRequirement());
    });
});

builder.Services.AddSingleton<IAuthorizationHandler, SuperAdminRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, TeacherRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, StudentRequirementHandler>();

builder.Services.AddRazorPages();
builder.Services.AddSingleton<SuperAdminDataSeed>();
builder.Services.AddControllersWithViews();


try
{
    var app = builder.Build();
    app.Services.GetAutofacRoot();
    var dataSeed = new SuperAdminDataSeed();
    dataSeed.Resolve(app.Services.GetAutofacRoot());
    await dataSeed.SeedUserAsync();

    Log.Information("Application Starting up");

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
    app.UseSession();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}



