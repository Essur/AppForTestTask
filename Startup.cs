using AppForTestTask.Data;
using AppForTestTask.Services;
using Microsoft.EntityFrameworkCore;

namespace AppForTestTask
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<DbForTestTaskContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<FolderImportExportService>();

            services.AddMvc();
		}
		
		public void Configure(IApplicationBuilder app)
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();

			app.UseHttpsRedirection();
			app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
	}
}
