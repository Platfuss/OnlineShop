using DataAccess.DatabaseAccess;
using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Services.Interfaces;

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
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                });
        });
        builder.Services.AddSingleton<IDatabase, MsSql>();
        builder.Services.AddSingleton<IAddressService, AddressService>();
        builder.Services.AddSingleton<ICartsService, CartsService>();
        builder.Services.AddSingleton<ICustomersService, CustomersService>();
        builder.Services.AddSingleton<IItemsService, ItemsService>();
        builder.Services.AddTransient<IFileService, ImageService>();
        builder.Services.AddSingleton<IOrderDetailsService, OrderDetailsService>();
        builder.Services.AddSingleton<IOrdersService, OrdersService>();

        return builder;
    }
}