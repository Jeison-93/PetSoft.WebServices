using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetSoft.WebServices.Application;
using PetSoft.WebServices.Application.Interface;
using PetSoft.WebServices.Data.Models;
using PetSoft.WebServices.Helpers;

var builder = WebApplication.CreateBuilder(args);

// REGISTRAR LA INTERFACE Y LA CLASE EN EL PROGRAMA
builder.Services.AddScoped<IGenericTableAppService, GenericTableAppService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IClientAppService, ClientAppService>();
builder.Services.AddScoped<IAuthAppService, UserAuthAppService>();
builder.Services.AddScoped<IPetAppService, PetAppService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetSection("ContextHelper").Get<ContextHelper>();

builder.Services.AddDbContextPool<PetsoftdbContext>
    (option => option.UseMySql(connectionString?.ConnectionString, ServerVersion.AutoDetect(connectionString?.ConnectionString)));

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
