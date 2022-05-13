using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Attributes
{
	[AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
	public class ColumnNameAttribute:Attribute
	{
		public string Value
		{
			get;
			private set;
		}

		public ColumnNameAttribute(string Value)
		{
			this.Value = Value;
		}
	}
}
