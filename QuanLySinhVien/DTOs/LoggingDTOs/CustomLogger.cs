using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using System.Data;

namespace QuanLySinhVien.DTOs.LoggingDTOs
{
	public static class CustomLogger
	{
		static CustomLogger()
		{
			var sinkOptions = new MSSqlServerSinkOptions()
			{
				TableName = "Logging",
				AutoCreateSqlTable = true
			};
			var connectionString = "Server=DESKTOP-2FT77HR\\SQLEXPRESS; Database=QLSV;Trusted_Connection=True";

			Log.Logger = new LoggerConfiguration()
		   .MinimumLevel.Information()
		   .WriteTo.MSSqlServer(connectionString, sinkOptions, null, null,
			Serilog.Events.LogEventLevel.Information, columnOptions: GetColumnOptions())
		   .CreateLogger();
		}

		private static ColumnOptions GetColumnOptions()
		{
			var columnOptions = new ColumnOptions();


			// Override the default Primary Column of Serilog by custom column name
			columnOptions.Id.ColumnName = "LogId";


			// Removing all the default column
			columnOptions.Store.Remove(StandardColumn.TimeStamp);
			columnOptions.Store.Remove(StandardColumn.Message);
			columnOptions.Store.Remove(StandardColumn.Level);
			columnOptions.Store.Remove(StandardColumn.Exception);
			columnOptions.Store.Remove(StandardColumn.MessageTemplate);
			columnOptions.Store.Remove(StandardColumn.Properties);


			// Adding all the custom columns
			columnOptions.AdditionalColumns = new List<SqlColumn>
			{
				new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Message", DataLength = 250, AllowNull = false},
				new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "LoggedBy",DataLength = 50, AllowNull = false },
				new SqlColumn { DataType = SqlDbType.DateTime, ColumnName = "LoginTime", DataLength = 7, AllowNull = false },
			};
			return columnOptions;
		}

		public static void Information(string message, string loggedBy)
		{
			Log.Logger.Information("{Message}{LoggedBy}{LoginTime}", message, loggedBy, DateTime.Now);
		}
	}
}
