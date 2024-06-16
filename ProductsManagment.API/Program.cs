using ProductsManagment.BLL.Services;
using ProductsManagment.DAL.Repository;
using System.Text.Json.Serialization;
using System.Text.Json;
using ProductsManagment.Common;
using ProductsManagment.API.ErrorHandling.Middleware;
using ProductsManagment.API.ServiceManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddProviderSettings(builder.Configuration);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IProductValidation, ProductValidation>();

builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new CategoryConverter());
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandling>();

app.UseAuthorization();

app.MapControllers();

app.Run();
