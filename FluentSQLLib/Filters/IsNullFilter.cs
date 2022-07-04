using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
