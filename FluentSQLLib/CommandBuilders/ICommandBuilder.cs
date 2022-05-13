using FluentSQLLib.Queries;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.CommandBuilders
{
	public interface ICommandBuilder
	{
		DbCommand BuildCommand<T>(IQuery Query);
	}
}
