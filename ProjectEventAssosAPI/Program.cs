using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using ProjectEventAssos.Infrastucture.Repositories;
using ProjectEventAssosAPI.Extension;
using ProjectEventAssosAPI.Scalar;
using Scalar.AspNetCore;
using ProjectEventAssos.Infrastucture.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Configuration des cors
builder.Services.ConfigurePolicyCors(builder.Configuration);

// Add services to the container.
builder.Services.ConfigureJwTAuthentication(builder.Configuration);
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.AddAuthorization();    

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options => options.AddDocumentTransformer<BearerSecuritySchemeTransformer>());

var app = builder.Build();

// Configure the HTTP request pipeline.
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
