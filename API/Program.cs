using DataAccess.DatabaseAccess;
using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Services.Interfaces;
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
        builder.Services.AddSingleton<IDatabase, MsSql>();
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<ICartsService, CartsService>();
        builder.Services.AddScoped<ICustomersService, CustomersService>();
        builder.Services.AddScoped<IItemsService, ItemsService>();
        builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();
        builder.Services.AddTransient<IFileService, ImageService>();

        return builder;
    }
}