using Loggy.Api.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Loggy.Api.Config
{
	public class RepoAndDataAccessDependencyInjectionConfig
	{
		public void RegisterForDependencyInjection(IServiceCollection services, IConfiguration appConfig)
		{
			services.AddTransient<IMongoClient, MongoClient>(sp => new MongoClient(appConfig["DbConnectionString"]));

			services.AddTransient<ILogEntryRepository, LogEntryRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ILogSubjectRepository, LogSubjectRepository>();
			services.AddTransient<IDataTypeRepository, DataTypeRepository>();
		}
	}
}
