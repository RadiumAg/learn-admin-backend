using Autofac;
using Autofac.Extensions.DependencyInjection;
using LearnAdmin.Extensions;
using LearnAdmin.Extensions.ServiceExtensions;
using LearnAdmin.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer((ContainerBuilder builder) =>
{
    builder.RegisterModule(new AutofacModuleRegister());
});

builder.Services.AddControllers((options) =>
{
    options.SuppressAsyncSuffixInActionNames = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapperSetup();
builder.Services.AddAuthentication((options) =>
{
    options.RequireAuthenticatedSignIn = false;
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(2);
    options.SlidingExpiration = true;
    options.Events = new CookieAuthenticationEvents()
    {
        OnRedirectToReturnUrl = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        },
        OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        },
        OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = 401;
            return Task.CompletedTask;
        }
    };
});
var configuration = builder.Configuration;

builder.Services.AddDbContext<LearnAdminContext>(config =>
{
    if (configuration == null) return;
    var str = configuration["Database:Connection"];
    config.UseMySql(str, ServerVersion.AutoDetect(str));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
});
app.UseAuthorization();

app.MapControllers();

app.Run();


