using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public class IsNullFilter : IIsNullFilter
	{
		private IColumn column;
		public IColumn Column => column;



		public IsNullFilter(IColumn Column)
		{
			if (Column == null) throw new ArgumentNullException(nameof(Column));
			this.column = Column;
		}

		public string Format(string FormattedColumn)
		{
			if (FormattedColumn == null) throw new ArgumentNullException(nameof(FormattedColumn));
			return $"{FormattedColumn} IS NULL";
		}

		public IAndFilter And(IFilter Filter)
		{
			if (Filter == null) throw new ArgumentNullException(nameof(Filter));
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
			if (Filter == null) throw new ArgumentNullException(nameof(Filter));
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
