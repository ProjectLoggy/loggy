using System.Collections.Generic;
using System.Threading.Tasks;
using Loggy.Api.Model.Model;

namespace Loggy.Api.DataAccess.MongoDb.DataAccess
{
	public interface IDataTypeRepository
	{
		Task<DataTypeDefinition> GetById(string dataTypeId);
		
		Task<IList<DataTypeDefinition>> GetAll();
	}

	public class DataTypeRepository: IDataTypeRepository
	{
		public Task<DataTypeDefinition> GetById(string dataTypeId)
		{
			return Task.FromResult(new DataTypeDefinition("dt111", "String"));
		}

		public Task<IList<DataTypeDefinition>> GetAll()
		{
			return Task.FromResult((IList<DataTypeDefinition>)new List<DataTypeDefinition>()
			{
				new DataTypeDefinition("dt111", "String"),
				new DataTypeDefinition("dt222", "DateTime"),
				new DataTypeDefinition("dt333", "Int32")
			});		
		}
	}
}
