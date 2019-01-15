using GraphQL.Types;

namespace Loggy.Api.Model
{
	public class User
	{
		public string UserId { get; set; }
		public string UserName { get; set; }

		public User(string userId, string userName)
		{
			UserId = userId;
			UserName = userName;
		}
	}

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
