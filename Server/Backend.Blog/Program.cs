using System.Collections.Immutable;
using Backend.BaseRepository;
using Backend.BaseService;
using Backend.Blog.EFCore.DBContext;
using Backend.Blog.Model;
using Backend.IBaseRepository;
using Backend.IBaseService;
using Backend.Util.Mapper;
using Microsoft.AspNetCore.Identity;
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
        
        //inject identity
        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequiredLength = 6;
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireLowercase = false;
            opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
            opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        });
        IdentityBuilder ibuilder = new IdentityBuilder(typeof(User), typeof(Role), services);
            
        ibuilder.AddEntityFrameworkStores<MysqlDBCOntext>()
            .AddDefaultTokenProviders()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>();
        services.AddDataProtection();

        return services;
    }
}