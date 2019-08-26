﻿using GraphQL.Types;
using Loggy.Api.DataAccess.MongoDb.DataAccess;

namespace Loggy.Api.GraphQlSchema.Queries
{
	public class LogEntriesQuery: ObjectGraphType
	{
		public LogEntriesQuery(ILogEntryRepository repo)
		{
			Name = "LogEntriesQuery";

			Field<ListGraphType<LogEntryGraphType>>(
				name: "logEntriesForUser",
				arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
				resolve: ctx => repo.GetAllForUserAsync(ctx.GetArgument<string>("userId")).Result);
		}
	}
}
