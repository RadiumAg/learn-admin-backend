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
builder.Services.AddAuthentication().AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(2);
    options.SlidingExpiration = true;
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


