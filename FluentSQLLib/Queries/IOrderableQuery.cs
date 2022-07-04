using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Queries
{
	public interface IOrderableQuery : IQuery
	{

		IEnumerable<ISort> Sorts
		{
			get;
		}

	}
}
