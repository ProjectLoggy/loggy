using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Loggy.Api.Schema
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
