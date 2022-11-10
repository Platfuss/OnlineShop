using DataAccess.DatabaseAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace API.Extentions;

public static class WebApplicationBuilderExtension
{
    public static void Configure(this WebApplicationBuilder builder, string policyName)
    {
        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSwaggerGen(opts =>
        {
            opts.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Authorization using Bearer scheme",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            opts.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("DataAccess"));
        });
        //TODO: check Corses
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                policy =>
                {
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                    policy.SetIsOriginAllowed(origin => true);
                    policy.AllowCredentials();
                    policy.WithOrigins("http://localhost:3000");
                });
        });

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration.GetSection("Jwt:Token").Value)),

                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies[builder.Configuration.GetSection("Jwt:JwtName").Value];
                        return Task.CompletedTask;
                    }
                };
            });

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddScoped<ICartsService, CartsService>();
        builder.Services.AddScoped<ICustomersService, CustomersService>();
        builder.Services.AddScoped<IItemsService, ItemsService>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddTransient<IFileService, ImageService>();
    }
}
