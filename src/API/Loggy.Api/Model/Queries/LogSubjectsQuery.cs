using GraphQL.Types;
using Loggy.Api.DataAccess;

namespace Loggy.Api.Model.Queries
{
	public class LogSubjectsQuery: ObjectGraphType
	{
		public LogSubjectsQuery(ILogSubjectRepository repo)
		{
			Name = "LogSubjectsQuery";

			Field<ListGraphType<LogSubjectDefinitionGraphType>>(
				name: "allLogSubjects",
				resolve: ctx => repo.GetAllAsync().Result);

			Field<LogSubjectDefinitionGraphType>(
				name: "logSubject",
				arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "logSubjectId" }),
				resolve: ctx => repo.GetById(ctx.GetArgument<string>("logSubjectId")).Result);
		}
	}
}
