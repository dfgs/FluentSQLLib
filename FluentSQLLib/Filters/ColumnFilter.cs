using FluentSQLLib.Columns;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public abstract class ColumnFilter:IColumnFilter
	{
		private IColumn column;
		public IColumn Column => column;

		private object value;
		public object Value => value;


		public ColumnFilter(IColumn Column,object Value)
		{
			if (Value == null) throw new ArgumentNullException(nameof(Value));
			this.column = Column;this.value = Value;
		}

		public abstract string Format(string FormattedColumn, string FormattedParameter);

		public IAndFilter And(IFilter Filter)
		{
			if (Filter is IAndFilter other)
			{
				other.Add(this);
				return other;
			}
			else
			{
				return new AndFilter(this, Filter);
			}
		}

		public IOrFilter Or(IFilter Filter)
		{
			if (Filter is IOrFilter other)
			{
				other.Add(this);
				return other;
			}
			else
			{
				return new OrFilter(this, Filter);
			}
		}
	}
}
