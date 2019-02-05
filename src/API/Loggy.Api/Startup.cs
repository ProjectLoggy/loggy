using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Loggy.Api.DataAccess;
using Loggy.Api.Model;
using Loggy.Api.Model.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Schema = Loggy.Api.Model.Schema;

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
			RegisterRepositoriesAndDataAccess(services);
			RegisterGraphQlTypes(services);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

			app.UseGraphiQl();
			app.UseMvc();
		}

		private static void RegisterGraphQlTypes(IServiceCollection services)
		{
			services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

			RegisterQueryServices(services);
			RegisterGraphTypes(services);

			var serviceProvider = services.BuildServiceProvider();
			services.AddSingleton<ISchema>(
				new Schema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
		}

		private void RegisterRepositoriesAndDataAccess(IServiceCollection services)
		{
			services.AddTransient<IMongoClient, MongoClient>(sp => new MongoClient(Configuration["DbConnectionString"]));

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
	}
}