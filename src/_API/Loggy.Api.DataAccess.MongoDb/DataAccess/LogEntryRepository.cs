using System.Collections.Generic;
using System.Threading.Tasks;
using Loggy.Api.Model.Model;

namespace Loggy.Api.DataAccess.MongoDb.DataAccess
{
	public interface ILogEntryRepository
	{
		/// <summary>
		/// Not possible to fetch all log entries in the database. Must be fetched with a userId to return
		///   log entries for the user.
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		Task<IList<LogEntry>> GetAllForUserAsync(string userId);
	}

	public class LogEntryRepository : ILogEntryRepository
	{
		public Task<IList<LogEntry>> GetAllForUserAsync(string userId)
		{
			return Task.FromResult((IList<LogEntry>)new List<LogEntry>()
			{
				new LogEntry()
			});
		}

	}
}
