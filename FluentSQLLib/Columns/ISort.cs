using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public interface ISort
	{
		IColumn Column
		{
			get;
		}

		OrderModes OrderMode
		{
			get;
		}

	}
}
