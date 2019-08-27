using GraphQL.Types;
using Loggy.Api.Model;

namespace Loggy.Api.GraphQlSchema
{
	public class LogEntryGraphType : ObjectGraphType<LogEntry>
	{
		public LogEntryGraphType()
		{
			Name = "LogEntry";
			Description = "A single log entry for a user. May contain multiple logFieldEntries.";

			Field(l => l.Name, nullable:true);
		}
	}
}
