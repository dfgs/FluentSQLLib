using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public interface IFilter
	{
		IAndFilter And(IFilter Filter);
		IOrFilter Or(IFilter Filter);

	}




}
