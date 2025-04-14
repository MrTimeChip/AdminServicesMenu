using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(option =>
{
    option.AddServer(new OpenApiServer
        {
            Url = "/",
            Description = "AdminServicesMenu"
        }
    );
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "AdminServicesMenu",
        Version = "v1"
    });
    option.DescribeAllParametersInCamelCase();
    option.SupportNonNullableReferenceTypes();
});

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
await app.RunAsync();