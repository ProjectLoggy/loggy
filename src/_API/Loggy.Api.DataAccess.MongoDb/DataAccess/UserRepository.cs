using System.Threading.Tasks;
using Loggy.Api.Model.Model;

namespace Loggy.Api.DataAccess.MongoDb.DataAccess
{
	public interface IUserRepository
	{
		Task<User> GetByIdAsync(string userId);
	}
	
	public class UserRepository: IUserRepository
	{
		public Task<User> GetByIdAsync(string userId)
		{
			return Task.FromResult(new User(userId, $"{userId}Name"));
		}
	}
}
