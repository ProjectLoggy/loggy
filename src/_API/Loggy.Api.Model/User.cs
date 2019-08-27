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
}
