using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LearnAdminContext>(dbContext =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));
    dbContext.UseMySql(builder.Configuration["database:connection"], serverVersion)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableServiceProviderCaching()
    .EnableDetailedErrors();
});
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
app.UseAuthorization();

app.MapControllers();

app.Run();


