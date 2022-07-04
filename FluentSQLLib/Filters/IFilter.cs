using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public interface IFilter
	{
		IAndFilter And<T>(Expression<Func<T, bool>> FilterExpression);
		IOrFilter Or<T>(Expression<Func<T, bool>> FilterExpression);

	}




}
