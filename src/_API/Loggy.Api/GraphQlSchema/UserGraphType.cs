using GraphQL.Types;
using Loggy.Api.Model;

namespace Loggy.Api.GraphQlSchema
{
	public class UserGraphType: ObjectGraphType<User>
	{
		public UserGraphType()
		{
			Name = "User";

			Field("userId", u => u.UserId, nullable: false);
			Field("userName", u => u.UserName, nullable: false);
		}
	}
}
