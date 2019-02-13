using GraphQL.Types;
using Loggy.Api.DataAccess.MongoDb.DataAccess;

namespace Loggy.Api.GraphQlSchema.Queries
{
	public class UsersQuery: ObjectGraphType
	{
		public UsersQuery(IUserRepository repo)
		{
			Name = "UsersQuery";

			Field<UserGraphType>(
				name: "user",
				arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
				resolve: ctx => repo.GetByIdAsync(ctx.GetArgument<string>("userId")).Result);
		}
	}
}
