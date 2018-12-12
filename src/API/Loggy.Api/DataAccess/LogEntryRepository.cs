using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loggy.Api.Schema;

namespace Loggy.Api.DataAccess
{
	public interface ILogEntryRepository
	{
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
