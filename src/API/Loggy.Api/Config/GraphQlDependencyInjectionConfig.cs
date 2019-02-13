using GraphQL;
using GraphQL.Types;
using Loggy.Api.GraphQlSchema;
using Loggy.Api.GraphQlSchema.Queries;
using Loggy.Api.Model;
using Microsoft.Extensions.DependencyInjection;
using Schema = Loggy.Api.GraphQlSchema.Schema;

namespace Loggy.Api.Config
{
	public class GraphQlDependencyInjectionConfig
	{
		public void RegisterForDependencyInjection(IServiceCollection services)
		{
			services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

			RegisterQueryServices(services);
			RegisterGraphTypes(services);

			var serviceProvider = services.BuildServiceProvider();
			services.AddSingleton<ISchema>(
				new Schema(new FuncDependencyResolver(type => serviceProvider.GetService(type))));
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
