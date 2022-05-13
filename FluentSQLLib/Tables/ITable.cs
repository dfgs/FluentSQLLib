using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Tables
{
	public interface ITable
	{
		string Name
		{
			get;
		}
	}
}
