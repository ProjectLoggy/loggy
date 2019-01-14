using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loggy.Api.Schema;
using Loggy.Api.Schema.Queries;

namespace Loggy.Api.DataAccess
{
	public interface ILogEntryRepository
	{
		Task<IList<SubObject>> GetAllForUserAsync(string userId);
	}

	public class LogEntryRepository : ILogEntryRepository
	{
		public Task<IList<SubObject>> GetAllForUserAsync(string userId)
		{
			return Task.FromResult((IList<SubObject>)new List<SubObject>()
			{
				new SubObject()
			});
		}

	}
}
