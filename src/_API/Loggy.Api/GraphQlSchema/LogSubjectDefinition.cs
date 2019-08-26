using GraphQL.Types;
using Loggy.Api.DataAccess.MongoDb.DataAccess;
using Loggy.Api.Model.Model;

namespace Loggy.Api.GraphQlSchema
{
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
