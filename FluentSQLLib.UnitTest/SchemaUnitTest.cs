using FluentSQLLib.UnitTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentSQLLib.UnitTest
{
	[TestClass]
	public class SchemaUnitTest
	{
		[TestMethod]
		public void ShouldGetTableNameFromClassWithoutAttributes()
		{
			Assert.AreEqual("TableWithoutAttributes", Schema<TableWithoutAttributes>.TableName);

		}
		[TestMethod]
		public void ShouldGetTableNameFromClassWithAttributes()
		{
			Assert.AreEqual("Table", Schema<TableWithAttributes>.TableName);

		}
	}
}