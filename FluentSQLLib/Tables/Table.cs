using FluentSQLLib.Attributes;
using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FluentSQLLib.Tables
{
	public class Table : ITable
	{

		private string name;
		public string Name => name;

		
		public Table(string Name)
		{
			this.name= Name;
		}

		

	
		public override string ToString()
		{
			return Name;
		}


	}
}
