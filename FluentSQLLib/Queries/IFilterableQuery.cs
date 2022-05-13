using FluentSQLLib.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Queries
{
	public interface IFilterableQuery : IQuery
	{
		IEnumerable<IFilter> Filters
		{
			get;
		}

	}
}
