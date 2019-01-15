using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Loggy.Api.DataAccess;
using Loggy.Api.Model;
using Loggy.Api.Model.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Schema = Loggy.Api.Model.Schema;

namespace Loggy.Api
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			
			services.AddTransient<ILogEntryRepository, LogEntryRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ILogSubjectRepository, LogSubjectRepository>();
			
			services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

			RegisterQueryServices(services);
			RegisterGraphTypeServices(services);

			var serviceProvider = services.BuildServiceProvider();
			services.AddSingleton<ISchema>(
				new Schema(resolver: 
					new FuncDependencyResolver(resolver: type => serviceProvider.GetService(type))));
		}

		private static void RegisterQueryServices(IServiceCollection services)
		{
			services.AddSingleton<RootQuery>();
			services.AddSingleton<LogEntriesQuery>();
		}

		private static void RegisterGraphTypeServices(IServiceCollection services)
		{
			services.AddSingleton<LogEntryGraphType>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseGraphiQl();
			app.UseMvc();
		}
	}
}
