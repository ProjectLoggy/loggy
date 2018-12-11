using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace Loggy.Api.Schema
{
	public class LogsQuery: ObjectGraphType
	{
		public LogsQuery()
		{
			Field<StringGraphType>(
				name: "logEntries",
				resolve: ctx => "Individual log entries here.");

			Field<StringGraphType>(
				name: "logSubjects",
				resolve: ctx => "Metadata about log entries.");

			Field<StringGraphType>(
				name: "dataTypeDefinition",
				resolve: ctx => "Data type definitions describing fields on logSubjects.");
		}
	}
}
