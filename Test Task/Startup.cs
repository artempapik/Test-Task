using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Test_Task.Models;

namespace Test_Task
{
	public class Startup
	{
		public Startup(IConfiguration configuration) => Configuration = configuration;

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddDbContext<ApplicationContext>()
				.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app
				.UseHttpsRedirection()
				.UseStaticFiles()
				.UseMvcWithDefaultRoute()
				.UseSpaStaticFiles();

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "ClientApp";

				if (env.IsDevelopment())
				{
					spa.UseAngularCliServer(npmScript: "start");
				}
			});
		}
	}
}