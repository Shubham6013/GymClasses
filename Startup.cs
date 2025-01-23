using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GymClassesAPI.Repository;
using GymClassesAPI.Service;

namespace GymClassesAPI
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			// Configure DbContext with SQLite
			services.AddDbContext<GymContext>(options =>
				options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

			// Dependency Injection
			services.AddScoped<IGymClassesRepository, GymClassesRepository>();
			services.AddScoped<IGymClassesService, GymClassesService>();

			// Add Controllers
			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
