using Backend.BaseRepository;
using Backend.BaseService;
using Backend.Blog.EFCore.DBContext;
using Backend.IBaseRepository;
using Backend.IBaseService;
using Backend.Util.Mapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MysqlDBCOntext>(opt =>
{
    opt.UseMySql(builder.Configuration.GetSection("constr").Value, new MySqlServerVersion(new Version(10,7,1)));
});

//inject auto mapper
builder.Services.AddAutoMapper(typeof(DTOMapper)); 

//custom inject
builder.Services.InjectCustom();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();


public static class IocExtend
{
    public static IServiceCollection InjectCustom(this IServiceCollection services)
    {
        //inject repository
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleTypeRepository, ArticleTypeRepository>();
        
        //inject service
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IArticleTypeService, ArticleTypeService>();

        return services;
    }
}