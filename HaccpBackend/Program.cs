using HaccpBackend.Interceptor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

//builder.Services.AddDbContext<ApplicationDbContext>((sp, optionsBuilder) =>
//{
//    var auditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>();

//    optionsBuilder.UseNpgsql(connectionString,)
//})

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
