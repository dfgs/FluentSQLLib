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
	public interface ISelect<T>: IOrderableQuery
	{
		int Limit
		{
			get;
		}
		IEnumerable<IColumn> Columns
		{
			get;
		}
		IFilter? Filter
		{
			get;
		}
		//ISelect From<T>();

		ISelect<T> AllColumns();
		ISelect<T> AllColumns<TTable>();
		ISelect<T> Column(Expression<Func<T,object?>> ValueExpression);
		ISelect<T> Column<TTable>(Expression<Func<TTable, object?>> ValueExpression);
		ISelect<T> Where(IFilter Filter);
		ISelect<T> OrderBy(Expression<Func<T, object?>> ValueExpression, OrderModes OrderMode=OrderModes.ASC);
		ISelect<T> OrderBy<TTable>(Expression<Func<TTable, object?>> ValueExpression, OrderModes OrderMode = OrderModes.ASC);
		ISelect<T> Top(int Limit);


	}
}
