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
	public interface ISelect: IQuery, IFilterableQuery,IOrderableQuery, IJoinableQuery
	{
		int Limit
		{
			get;
		}
		IEnumerable<IColumn> Columns
		{
			get;
		}

		

		

		ISelect AllFrom<TTable>();
		ISelect From<TTable>(params Expression<Func<TTable, object?>>[] Columns);
		ISelect Where(IFilter Filter);
		ISelect OrderBy<TTable>(Expression<Func<TTable, object?>> Column, OrderModes OrderMode = OrderModes.ASC);
		ISelect Top(int Limit);
		ISelect Join<TTable1,TTable2>(Expression<Func<TTable1, object?>> Column1, Expression<Func<TTable2, object?>> Column2);


	}
}
