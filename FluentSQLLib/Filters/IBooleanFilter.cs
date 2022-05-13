using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public interface IBooleanFilter:IFilter
	{
		IEnumerable<IFilter> Members
		{
			get;
		}
		string Format(IEnumerable<string> FormattedMembers);

		void Add(IFilter Filter);
	}

	



}
