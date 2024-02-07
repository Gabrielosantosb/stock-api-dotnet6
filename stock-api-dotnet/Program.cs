using Microsoft.EntityFrameworkCore;
using stock_api_dotnet.ORM.Context;
using stock_api_dotnet.ORM.Models.User;
using stock_api_dotnet.Repository;
using stock_api_dotnet.Services;
using stock_api_dotnet.Services.Category;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region mysqlConfig
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<StockDbContext>(options =>
{
    options.UseMySql(connectionString, serverVersion);
});
#endregion mysqlConfig

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<BaseRepository<UserModel>>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<ICreateUserService, CreateUserService>();
builder.Services.AddScoped<IAuthUserService, AuthUserService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplica as migratrions pendentes
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<StockDbContext>();

    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); 

app.Run();
