using Microsoft.EntityFrameworkCore;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using ProjectEventAssos.Infrastucture.Repositories;
using ProjectEventAssosAPI.Extension;
using ProjectEventAssosAPI.Scalar;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AssocEventContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ));

// Configuration des cors
builder.Services.ConfigurePolicyCors(builder.Configuration);

// Add services to the container.
builder.Services.ConfigureJwTAuthentication(builder.Configuration);
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

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
