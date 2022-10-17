using DataAccess.DatabaseAccess;
using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Services.Interfaces;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        const string policyName = "DevelopmentPolicy";

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

        var app = builder.Build();

        // Configure the HTTP request pipeline.
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
}