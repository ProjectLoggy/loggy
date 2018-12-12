using GraphQL;
using GraphQL.Types;
using Loggy.Api.DataAccess;

namespace Loggy.Api.Schema.Queries
{
	public class RootQuery: ObjectGraphType
	{
		public RootQuery(IDependencyResolver resolver)
		{
			Name = "Query";

			Field<LogEntriesQuery>(
				name: "logEntries",
				resolve: ctx => resolver.Resolve<LogEntriesQuery>());

			Field<StringGraphType>(
				name: "logSubjects",
				resolve: ctx => "Metadata about log entries. Still todo.");

			Field<StringGraphType>(
				name: "dataTypeDefinition",
				resolve: ctx => "Data type definitions describing fields on logSubjects. Still todo.");
		}
	}
}
