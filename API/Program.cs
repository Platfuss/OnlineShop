using DataAccess.DatabaseAccess;
using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        const string policyName = "DevelopmentPolicy";
        var app = GetBuilder(args, policyName).Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors(policyName);
        app.UseAuthentication();

        app.Run();
    }

    private static WebApplicationBuilder GetBuilder(string[] args, string policyName)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("DataAccess"));
        });
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                });
        });
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                //TODO: Add builder.config appsettings
                ValidIssuer = "https://localhost:7177",
                ValidAudience = "https://localhost:7177",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VjcKumQGFKbtDPO19zqThjDAreu2u6Tl"))
            };
        });

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
        builder.Services.AddScoped<ICartsService, CartsService>();
        builder.Services.AddScoped<ICustomersService, CustomersService>();
        builder.Services.AddScoped<IItemsService, ItemsService>();
        builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();
        builder.Services.AddTransient<IFileService, ImageService>();

        return builder;
    }
}