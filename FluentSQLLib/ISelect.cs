﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib
{
	public interface ISelect:IQuery
	{
		string TableName
		{
			get;
		}
	}
}
