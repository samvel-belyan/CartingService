using AutoMapper;
using BLL.Implementations;
using BLL.Interfaces;
using CartingApi.Profiles;
using DAL.Implementations;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICartingDbContext, CartingDbContext>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartService, CartService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new CartingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddApiVersioning(o =>
{
    //o.UseApiBehavior = false;
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    o.ReportApiVersions = true;
    o.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
});


//builder.Services.AddApiVersioningConfigured();

//builder.Services.AddSwaggerSwashbuckleConfigured();

builder.Services.AddControllers();
builder.Services.AddSwaggerDocument();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    var descriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in descriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
