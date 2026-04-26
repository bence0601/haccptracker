using Carter;
using HaccpBackend.Data;
using HaccpBackend.Domain.Entities;
using HaccpBackend.Interceptor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDataContext>(
    (sp, optionsBuilder) =>
    {
        var auditableInterceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>();

        optionsBuilder
            .UseNpgsql(
                connectionString,
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
            .AddInterceptors(auditableInterceptor)
            .UseSnakeCaseNamingConvention();
    }
);

builder.Services.AddIdentity<User, IdentityRole<int>>().AddEntityFrameworkStores<AppDataContext>();

builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssembly(typeof(Program).Assembly)
);

builder.Services.AddCarter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDataContext>();
    dbContext.Database.Migrate();
}

app.MapCarter();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
