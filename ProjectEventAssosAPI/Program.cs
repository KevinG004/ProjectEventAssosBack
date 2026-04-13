using ProjectEventAssos.Infrastucture.Extensions;
using ProjectEventAssosAPI.Extension;
using ProjectEventAssosAPI.Scalar;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuration des cors
builder.Services.ConfigurePolicyCors(builder.Configuration);

// Add services to the container.
builder.Services.ConfigureJwTAuthentication(builder.Configuration);
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddOpenApi(options => options.AddDocumentTransformer<BearerSecuritySchemeTransformer>());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();