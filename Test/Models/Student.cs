using FluentSQLLib.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models
{
	[TableName("Student")]
	public class Student
	{
		public string Name { get; set; }
		public int Id { get; set; }

		public Student()
		{
			Name = "Undefined";
		}

	}
}
