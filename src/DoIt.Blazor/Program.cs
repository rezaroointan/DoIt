using DoIt.Blazor.Authentication;
using DoIt.Blazor.Components;
using DoIt.Core.Interfaces;
using DoIt.Core.Services;
using DoIt.Data.Context;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DoIt.Data.Entities.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add authentication services
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// Authentication options
builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

// Add database context
builder.Services.AddDbContext<DoItDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DoItDbConnection"));
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add identity core
builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<DoItDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Add services to the container
builder.Services.AddTransient<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
