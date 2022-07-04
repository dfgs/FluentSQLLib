using FluentSQLLib.Columns;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

		public IAndFilter And<T>(Expression<Func<T, bool>> FilterExpression)
		{
			IFilter filter;
			if (FilterExpression == null) throw new ArgumentNullException(nameof(FilterExpression));

			filter = ExpressionHelper.GetFilter(FilterExpression);
	
			if (filter is IAndFilter other)
			{
				other.Add(this);
				return other;
			}
			else
			{
				return new AndFilter(this, filter);
			}
		}

		public IOrFilter Or<T>(Expression<Func<T, bool>> FilterExpression)
		{
			IFilter filter;
			if (FilterExpression == null) throw new ArgumentNullException(nameof(FilterExpression));

			filter = ExpressionHelper.GetFilter(FilterExpression);

			if (filter is IOrFilter other)
			{
				other.Add(this);
				return other;
			}
			else
			{
				return new OrFilter(this, filter);
			}
		}
	}
}
