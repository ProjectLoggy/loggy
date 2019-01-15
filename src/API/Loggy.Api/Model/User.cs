using GraphQL.Types;

namespace Loggy.Api.Model
{
	public class User
	{
		public string UserId { get; set; }
		public string UserName { get; set; }
	}

	public class UserType: ObjectGraphType<User>
	{
		public UserType()
		{
			Name = "User";

			Field("userId", u => u.UserId, nullable: false);
			Field("userName", u => u.UserName, nullable: false);
		}
	}
}
