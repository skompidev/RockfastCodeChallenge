using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Rockfast.ApiDatabase;
using Rockfast.ApiDatabase.Extensions;
using Rockfast.Dependencies;
using Rockfast.Infrastructure.Exceptions;
using Rockfast.Infrastructure.Filters;
using Rockfast.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddExceptionHandler<ExceptionFilter>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IUserService, UserSerivice>();
builder.Services.AddScoped<ISaveChangesInterceptor, AuditingInerceptor>();
builder.Services.AddDbContext<ApiDbContext>((provider, options) => 
{
    options.AddInterceptors(provider.GetServices<ISaveChangesInterceptor>());
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
    options.Filters.Add<LoggingAsyncActionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseSwagger();
    app.UseSwaggerUI();
    //await app.InitialiseDbSeedAsync();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
