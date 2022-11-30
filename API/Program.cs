using API.Extentions;

internal class Program
{
    private static void Main(string[] args)
    {
        const string policyName = "MyPolicy";
        var builder = WebApplication.CreateBuilder(args);
        builder.Configure(policyName);

        var app = builder.Build();

        app.UseCors(policyName);

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}