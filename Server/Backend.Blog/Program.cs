using System.Collections.Immutable;
using System.Text;
using Backend.BaseRepository;
using Backend.BaseService;
using Backend.Blog.EFCore.DBContext;
using Backend.Blog.Filter;
using Backend.Blog.Model;
using Backend.IBaseRepository;
using Backend.IBaseService;
using Backend.Util;
using Backend.Util.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//启动Swagger鉴权组件
builder.Services.AddSwaggerGen(opt =>
{

    var scheme = new OpenApiSecurityScheme()
    {
        Description = $"Authorization header \r\n Example: 'Bearer xxxxxxxxxxxxxxxx'",
        Reference = new OpenApiReference() { Type = ReferenceType.SecurityScheme, Id = "Authorization" },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    };

    opt.AddSecurityDefinition("Authorization", scheme);

    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    opt.AddSecurityRequirement(requirement);

});

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MysqlDBCOntext>(opt =>
{
    opt.UseMySql(builder.Configuration.GetSection("constr").Value, new MySqlServerVersion(new Version(10,7,1)));
});

//注入Filter服务
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<JwtVersionCheckFilter>();
});

//读取配置文件中Jwt的信息,然后通过Configuration配置系统注入到Controller层进行授权
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("Jwt"));

//配置Jwt：鉴权
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {

        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSetting>();
        byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecKey);
        var secKey = new SymmetricSecurityKey(keyBytes);

        opt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,  //代表颁发Token的web应用程序

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,  //Token的受理者

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = secKey,
            ClockSkew = TimeSpan.FromSeconds(jwtSettings.ExpireSeconds)
        };

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