using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public static class Filter
	{
		public static IFilter Evaluate<T>(Expression<Func<T, bool>> FilterExpression)
		{
			IFilter filter;
			if (FilterExpression == null) throw new ArgumentNullException(nameof(FilterExpression));

			filter = ExpressionHelper.GetFilter(FilterExpression);

			return filter;
		}

	}
}
