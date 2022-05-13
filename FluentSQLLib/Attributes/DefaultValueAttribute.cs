using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DefaultValueAttribute:Attribute
	{
		public object Value
		{
			get;
			private set;
		}

		public DefaultValueAttribute(object Value)
		{
			this.Value = Value;
		}
	}
}
