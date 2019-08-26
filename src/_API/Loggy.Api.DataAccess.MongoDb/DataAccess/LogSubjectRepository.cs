using System.Collections.Generic;
using System.Threading.Tasks;
using Loggy.Api.Model.Model;

namespace Loggy.Api.DataAccess.MongoDb.DataAccess
{
	public interface ILogSubjectRepository
	{
		Task<LogSubjectDefinition> GetById(string logSubjectId);

		Task<IList<LogFieldDefinition>> GetFields(string logSubjectId);
		
		Task<IList<LogSubjectDefinition>> GetAllAsync();
	}

	public class LogSubjectRepository: ILogSubjectRepository
	{
		public Task<LogSubjectDefinition> GetById(string logSubjectId)
		{
			return Task.FromResult(new LogSubjectDefinition(logSubjectId, "A Subject"));
		}
		
		public Task<IList<LogSubjectDefinition>> GetAllAsync()
		{
			return Task.FromResult((IList<LogSubjectDefinition>)new List<LogSubjectDefinition>()
			{
				new LogSubjectDefinition("123", "Weight"),
				new LogSubjectDefinition("456", "Blood Pressure")
			});
		}

		public Task<IList<LogFieldDefinition>> GetFields(string logSubjectId)
		{
			return Task.FromResult((IList<LogFieldDefinition>)new List<LogFieldDefinition>()
			{
				new LogFieldDefinition("123f", "Value", "dataType111")
			});
		}
	}
}
