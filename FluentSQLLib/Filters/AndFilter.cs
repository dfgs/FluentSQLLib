using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public class AndFilter : BooleanFilter, IAndFilter
	{
		
		public AndFilter(params IFilter[] Members):base(Members)
		{
		}


		public override string Format(IEnumerable<string> FormattedMembers)
		{
			if (FormattedMembers == null) throw new ArgumentNullException(nameof(FormattedMembers));
			return $"({String.Join(" AND ", FormattedMembers)})";
		}

		public override IAndFilter And<T>(Expression<Func<T, bool>> FilterExpression)
		{
			IFilter filter;
			if (FilterExpression == null) throw new ArgumentNullException(nameof(FilterExpression));

			filter = ExpressionHelper.GetFilter(FilterExpression);
			if (filter is IAndFilter other)
			{
				foreach (IFilter item in other.Members) Add(item);
				return this;
			}
			else
			{
				Add(filter);
				return this;
			}
		}

		public override IOrFilter Or<T>(Expression<Func<T, bool>> FilterExpression)
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
