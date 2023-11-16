using AppForTestTask.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using AppForTestTask;

internal class Program
{
	private static void Main(string[] args)
	{
		var host = CreateWebHostBuilder(args).Build();

		using (var scope = host.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<DbForTestTaskContext>();
				DbInitializer.Initialize(context);
				FileInitializer.GenerateFile();
			}
			catch (Exception ex)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, "An error occurred while seeding the database.");
			}
		}

		host.Run();
	}
	public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
}