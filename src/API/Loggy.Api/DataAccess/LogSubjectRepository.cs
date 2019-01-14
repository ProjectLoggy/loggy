using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loggy.Api.Schema;

namespace Loggy.Api.DataAccess
{
	public interface ILogSubjectRepository
	{
		Task<LogSubjectDefinition> GetByIdAsync(string logSubjectId);
		
		Task<IList<LogSubjectDefinition>> GetAllAsync();
	}

	public class LogSubjectRepository: ILogSubjectRepository
	{
		public Task<LogSubjectDefinition> GetByIdAsync(string logSubjectId)
		{
			return Task.FromResult(new LogSubjectDefinition());
		}
		
		public Task<IList<LogSubjectDefinition>> GetAllAsync()
		{
			return Task.FromResult((IList<LogSubjectDefinition>)new List<LogSubjectDefinition>()
			{
				new LogSubjectDefinition()
			});
		}
	}
}
