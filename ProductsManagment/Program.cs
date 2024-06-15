using ProductsManagment.BLL.Services;
using ProductsManagment.DAL.Repository;
using ProductsManagment.ErrorHandling.Middleware;
using ProductsManagment.ServiceManager;

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
