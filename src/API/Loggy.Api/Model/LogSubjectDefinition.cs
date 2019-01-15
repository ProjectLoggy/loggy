using GraphQL.Types;
using Loggy.Api.DataAccess;

namespace Loggy.Api.Model
{
	public class LogSubjectDefinition
	{
		public string SubjectId { get; set; }
		public string SubjectName { get; set; }

		public LogSubjectDefinition(string subjectId, string subjectName)
		{
			SubjectId = subjectId;
			SubjectName = subjectName;
		}
	}

	public class LogSubjectDefinitionGraphType: ObjectGraphType<LogSubjectDefinition>
	{
		public LogSubjectDefinitionGraphType(ILogSubjectRepository repo)
		{
			Name = "LogSubjectDefinition";

			Field(l => l.SubjectName);
			Field(l => l.SubjectId);

			Field<ListGraphType<LogFieldDefinitionGraphType>>(
				name: "fields",
				resolve: ctx => repo.GetFields(ctx.Source.SubjectId).Result);
		}
	}
}
