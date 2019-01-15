using GraphQL;
using GraphQL.Types;

namespace Loggy.Api.Model.Queries
{
	public class RootQuery: ObjectGraphType
	{
		public RootQuery(IDependencyResolver resolver)
		{
			Name = "Query";

			Field<LogEntriesQuery>(
				name: "logEntries",
				resolve: ctx => new{ });
		}
	}
}
