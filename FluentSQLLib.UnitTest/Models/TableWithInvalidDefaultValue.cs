using FluentSQLLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.UnitTest.Models
{

	internal class TableWithInvalidDefaultValue
	{
		public string? Name { get; set; }
		
		
		[ColumnName("colID")]
		public int ID { get; set; }

		public TableWithInvalidDefaultValue()
		{
			Name = "no name";
		}
	}
}
