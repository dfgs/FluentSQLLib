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
	public interface IDelete: IQuery,IFilterableQuery, IJoinableQuery
	{
		string? Table
		{
			get;
		}

		IDelete From<TTable>();
		IDelete Where(IFilter Filter);
		IDelete Join<TTable1,TTable2>(Expression<Func<TTable1, object?>> Column1, Expression<Func<TTable2, object?>> Column2);


	}
}
