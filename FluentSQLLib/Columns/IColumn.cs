
using FluentSQLLib.Filters;
using FluentSQLLib.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public interface IColumn
	{
		string Name
		{
			get;
		}

		string Table
		{
			get;
		}
			   
		
	}

	

}
