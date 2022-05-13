using FluentSQLLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.UnitTest.Models
{

	[TableName("Table")]
	internal class TableWithAttributes
	{
		[ColumnName("colName"),DefaultValue("Homer")]
		public string Name { get; set; }
		[ColumnName("colID"),DefaultValue(12)]
		public int ID { get; set; }

		[ColumnName("colDescription"), DefaultValue(12)]
		public string? Description { get; set; }
		[ColumnName("colNullID"), DefaultValue(12)]
		public int? NullID { get; set; }

		public TableWithAttributes()
		{
			Name = "no name";
		}
	}
}
