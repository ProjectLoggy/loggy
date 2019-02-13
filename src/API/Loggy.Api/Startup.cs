using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Loggy.Api.Config;
using Loggy.Api.DataAccess;
using Loggy.Api.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Schema = Loggy.Api.GraphQlSchema.Schema;

namespace Loggy.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; set; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			
			new RepoAndDataAccessDependencyInjectionConfig()
				.RegisterForDependencyInjection(services, Configuration);
			
			new GraphQlDependencyInjectionConfig()
				.RegisterForDependencyInjection(services);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseGraphiQl();
			app.UseMvc();
		}
	}
}