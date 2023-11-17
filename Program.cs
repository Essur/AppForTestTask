using AppForTestTask.Data;
using Microsoft.EntityFrameworkCore;
using AppForTestTask.Services;

internal class Program
{
	private static void Main(string[] args)
	{
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        var connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DbForTestTaskContext>(options => options.UseSqlServer(connection));

		builder.Services.AddScoped<FolderImportExportService>();
		builder.Services.AddScoped<DbInitializer>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

		try
		{
			var dbInitializer = app.Services.CreateScope().ServiceProvider.GetRequiredService<DbInitializer>();
			dbInitializer.Initialize();
		}
		catch (Exception ex)
		{
			var logger = app.Services.CreateScope().ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while seeding the database.");
		}
        
		FileInitializer.GenerateFile();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}