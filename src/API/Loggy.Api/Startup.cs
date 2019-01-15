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
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			
			RegisterRepositories(services);

			services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

			RegisterQueryServices(services);
			RegisterGraphTypes(services);

			var serviceProvider = services.BuildServiceProvider();
			services.AddSingleton<ISchema>(
				new Schema(resolver: 
					new FuncDependencyResolver(resolver: type => serviceProvider.GetService(type))));
		}

		private static void RegisterRepositories(IServiceCollection services)
		{
			services.AddTransient<ILogEntryRepository, LogEntryRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ILogSubjectRepository, LogSubjectRepository>();
			services.AddTransient<IDataTypeRepository, DataTypeRepository>();
		}

		private static void RegisterQueryServices(IServiceCollection services)
		{
			services.AddSingleton<RootQuery>();
			services.AddSingleton<LogEntriesQuery>();
			services.AddSingleton<LogSubjectsQuery>();
			services.AddSingleton<UsersQuery>();
		}

		private static void RegisterGraphTypes(IServiceCollection services)
		{
			//Log Entries are related to Users:
			services.AddSingleton<UserGraphType>();

			//Log Entries have one or more LogFieldEntries:
			services.AddSingleton<LogEntryGraphType>();
			services.AddSingleton<LogFieldEntryGraphType>();

			//Log Entries represent LogSubjectDefinitions with Fields (which have Data Types).
			services.AddSingleton<LogSubjectDefinitionGraphType>();
			services.AddSingleton<LogFieldDefinitionGraphType>();
			services.AddSingleton<DataTypeDefinitionGraphType>();
		}

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
