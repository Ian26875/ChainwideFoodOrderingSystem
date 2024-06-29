using Asp.Versioning;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.DependencyInjection;
using ChainwideFoodOrderingSystem.Orders.WebAPI.Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Api Version
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1.0);
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}) 
.AddApiExplorer(options =>
{
    options.SubstituteApiVersionInUrl = true;
    options.GroupNameFormat = "'v'VVV";
    options.AssumeDefaultVersionWhenUnspecified = true;
});

// AutoMapper
builder.Services.AddAutoMapper
(
    o => o.AddProfile<OrderWebApiProfile>()
);

// Order Component
builder.Services.AddOrderUseCaseModule(builder.Configuration)
                .AddOrderPersistenceModule(builder.Configuration);




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



public partial class Program
{
    
}