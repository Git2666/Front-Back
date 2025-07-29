using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Server.Book.Domain.Interfaces;
using Server.Book.Infrastructure.EF.Oracle;
using Server.Book.Infrastructure.EF.Oracle.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8080); // 明确指定端口
});

// Add services to the container.
builder.Services.AddCors(
    c => c.AddPolicy
    ("any", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()
    )
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// 注册 EF Core with Oracle
builder.Services.AddDbContext<ServerBookDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb")));

// 注册仓储接口
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("any");

app.UseAuthentication(); 
app.UseAuthorization(); 

app.MapControllers();

app.Run();
