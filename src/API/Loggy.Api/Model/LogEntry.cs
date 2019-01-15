using GraphQL.Types;

namespace Loggy.Api.Model
{
	public class LogEntry
	{
		public string Name { get; set; }
	}

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
