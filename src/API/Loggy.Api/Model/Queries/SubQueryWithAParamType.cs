using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Loggy.Api.Model.Queries
{
	public class SubQueryWithAParamType: ObjectGraphType
	{
		public SubQueryWithAParamType()
		{
			Name = nameof(SubQueryWithAParamType);

			Field<StringGraphType>(
				name: "logEntriesForUser",
				arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "userId" }),
				resolve: ctx => "Your param:" + ctx.GetArgument<string>("userId"));
		}
	}
}
