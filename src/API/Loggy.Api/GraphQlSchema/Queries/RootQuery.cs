using GraphQL;
using GraphQL.Types;

namespace Loggy.Api.GraphQlSchema.Queries
{
	public class RootQuery: ObjectGraphType
	{
		public RootQuery(IDependencyResolver resolver)
		{
			Name = "Query";

			Field<LogEntriesQuery>(
				name: "logEntries",
				resolve: ctx => new{ });

			Field<LogSubjectsQuery>(
				name: "logSubjects",
				resolve: ctx => new{ });

			Field<UsersQuery>(
				name: "users",
				resolve: ctx => new{ });
		}
	}
}
