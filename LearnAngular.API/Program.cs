using LearnAngular.API.Data;
using LearnAngular.API.Models.Settings;
using LearnAngular.API.Repositories.Implementation;
using LearnAngular.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Amar Added MongoDB settings and DbContext configuration
var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddDbContext<MongoDbContext>(options => 
{
    options.UseMongoDB(mongoDBSettings.ConnectionURI ?? "", mongoDBSettings.DatabaseName ?? "");
});
// Enable CORS for all origins, methods, and headers
// Add CORS policy to allow all origins, methods, and headers

//Amar added SQL Server DbContext configuration
builder.Services.AddDbContext<ApplicationDbContext>(options => { 
    options.UseSqlServer(builder.Configuration.GetConnectionString("MarketDefaultConnection"));
});

builder.Services.AddScoped<IProductRepository,ProductRepository>();
 
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS for all origins, methods, and headers (this has to be AFTER UseHttpsRedirection)
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
