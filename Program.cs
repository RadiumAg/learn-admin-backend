using Microsoft.EntityFrameworkCore;
using learn_admin_backend.Share;

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
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{

    if (context.Response.StatusCode == 200)
    {
        var response = new Reponse<dynamic>()
        {
            Data = context.Response.Body,
            ErrorMessage = "success"
        };


    }else if(context.Response.StatusCode == 500)
    {

    }
    await next(context);
});

app.Run();


