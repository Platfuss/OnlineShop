using DataAccess.DatabaseAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.UseCors(policyName);

        app.Run();
    }

    private static WebApplicationBuilder GetBuilder(string[] args, string policyName)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
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

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                policy =>
                {
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
                    ValidateAudience = false
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