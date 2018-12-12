using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Loggy.Api.DataAccess;

namespace Loggy.Api.Schema
{
	public class LogEntry
	{
	}

	public class LogEntryType: ObjectGraphType<LogEntry>
	{
		public LogEntryType(ILogEntryRepository logEntryRepo, IUserRepository userRepo)
		{
			Name = "LogEntry";
			Description = "A single log entry, an 'instance' of a LogSubject. Contains LogFieldEntries.";

			//Todo...
			//Field<LogSubjectDefinitionType>("logSubject");
			//Field<ListGraphType<LogFieldEntryType>>("logFieldEntries");
			
			Field<UserType>(
				name: "user", 
				arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "userId" }),
				resolve: ctx => userRepo.GetByIdAsync(ctx.GetArgument<string>("userId")),
				description: "User that recorded the log entry.");
		}
	}
}
