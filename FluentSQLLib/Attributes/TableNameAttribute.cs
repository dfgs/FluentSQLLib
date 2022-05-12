using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Attributes
{
	[AttributeUsage(AttributeTargets.Class,AllowMultiple =false)]
	public class TableNameAttribute:Attribute
	{
		public string Value
		{
			get;
			private set;
		}

		public TableNameAttribute(string Value)
		{
			this.Value = Value;
		}
	}
}
