using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public interface IJoinCondition
	{
		IColumn Column1
		{
			get;
		}
		IColumn Column2
		{
			get;
		}
	}
}
