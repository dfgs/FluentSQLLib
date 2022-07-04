using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Queries
{
	public interface IUpdate<TTable>: IQuery,IFilterableQuery, IJoinableQuery
	{
		string Table
		{
			get;
		}
		IEnumerable<ISetter> Setters
		{
			get;
		}

		IUpdate<TTable> Set<TValue>(Expression<Func<TTable, TValue>> Column, TValue Value);
		IUpdate<TTable> Where(IFilter Filter);
		IUpdate<TTable> Join<TTable1,TTable2>(Expression<Func<TTable1, object?>> Column1, Expression<Func<TTable2, object?>> Column2);


	}
}
