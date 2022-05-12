using FluentSQLLib.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib
{
	public static class Schema<T>
	{
		public static string TableName
		{
			get;
			private set;
		}


		static Schema()
		{
			Type type;
			TableNameAttribute? tableNameAttribute;

			type=typeof(T);


			tableNameAttribute = type.GetCustomAttributes(typeof(TableNameAttribute), true).FirstOrDefault() as TableNameAttribute;
			TableName=tableNameAttribute?.Value??type.Name;


		}


	}
}
