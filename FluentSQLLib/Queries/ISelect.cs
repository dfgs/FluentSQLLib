using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using FluentSQLLib.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Queries
{
	public interface ISelect<T>:IQuery
	{
		int Limit
		{
			get;
		}
		IEnumerable<IColumn> Columns
		{
			get;
		}
		IEnumerable<IFilter> Filters
		{
			get;
		}
		//ISelect From<T>();

		ISelect<T> AllColumns();
		ISelect<T> Column<TVal>(Expression<Func<T, TVal>> ValueExpression);
		ISelect<T> Where(Expression<Func<T,bool>> FilterExpression);
		ISelect<T> OrderBy(params IColumn[] Columns);
		ISelect<T> OrderBy(OrderModes OrderMode, params IColumn[] Columns);
		ISelect<T> Top(int Limit);


	}
}
