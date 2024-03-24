using CleanArchitecture.Application;
using CleanArchitecture.Persistance;
using Core.CrossCuttingConcerns.Exceptions.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationService();
builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (app.Environment.IsProduction())
//{
//    app.ConfigureCustomExceptionMiddleware();
//}

//app.ConfigureCustomExceptionMiddleware();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
