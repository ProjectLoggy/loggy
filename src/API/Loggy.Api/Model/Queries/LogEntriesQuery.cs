using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Loggy.Api.DataAccess;

namespace Loggy.Api.Schema.Queries
{
	public class LogEntriesQuery: ObjectGraphType
	{
		public LogEntriesQuery(ILogEntryRepository repo)
		{
			Name = "LogEntriesQuery";

			Field<ListGraphType<MySubObjectGraphType>>(
				name: "logEntriesForUser",
				arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "userId" }),
				resolve: ctx => repo.GetAllForUserAsync(ctx.GetArgument<string>("userId")).Result);
		}
	}
}
