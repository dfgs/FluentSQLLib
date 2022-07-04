using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Queries
{
	public interface IJoinableQuery : IQuery
	{
		IEnumerable<IJoinCondition> JoinConditions
		{
			get;
		}

	}
}
