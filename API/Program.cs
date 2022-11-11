using API.Extentions;

internal class Program
{
    private static void Main(string[] args)
    {
        const string policyName = "DevelopmentPolicy";
        var builder = WebApplication.CreateBuilder(args);
        builder.Configure(policyName);

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(policyName);

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}