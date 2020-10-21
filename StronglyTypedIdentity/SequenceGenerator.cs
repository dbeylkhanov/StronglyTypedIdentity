using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace StronglyTypedIdentity
{
	public static class SequenceGenerator
	{
		public static int GetNextSequenceValue(this DbContext context, string sequenceName) {
			var sqlGenerator = context.GetService<IUpdateSqlGenerator>();
			string sql = sqlGenerator.GenerateNextSequenceValueOperation(sequenceName, context.Model.GetDefaultSchema());
			var rawCommandBuilder = context.GetService<IRawSqlCommandBuilder>();
			IRelationalCommand command = rawCommandBuilder.Build(sql);
			var connection = context.GetService<IRelationalConnection>();
			var logger = context.GetService<IDiagnosticsLogger<DbLoggerCategory.Database.Command>>();
			var parameters = new RelationalCommandParameterObject(connection, null, null, context, logger);
			object result = command.ExecuteScalar(parameters);
			return Convert.ToInt32(result, CultureInfo.InvariantCulture);
		}
	}
}