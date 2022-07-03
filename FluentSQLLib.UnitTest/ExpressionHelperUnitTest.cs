using FluentSQLLib.UnitTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FluentSQLLib.UnitTest
{
	[TestClass]
	public class ExpressionHelperUnitTest
	{
		[TestMethod]
		public void GetColumnName_ShouldGetPropertyNameFromClassWithoutAttributes()
		{
			Assert.AreEqual("Name", ExpressionHelper.GetPropertyName<TableWithoutAttributes,string?>(tbl => tbl.Name));
			Assert.AreEqual("ID", ExpressionHelper.GetPropertyName<TableWithoutAttributes, int?>(tbl => tbl.ID));
		}
		[TestMethod]
		public void GetColumnName_ShouldGetPropertyNameFromClassWithAttributes()
		{
			Assert.AreEqual("Name", ExpressionHelper.GetPropertyName<TableWithAttributes, string>(tbl => tbl.Name));
			Assert.AreEqual("ID", ExpressionHelper.GetPropertyName<TableWithAttributes, int>(tbl => tbl.ID));
		}
		[TestMethod]
		public void GetColumnName_ShouldThrowExceptionIfExpressionIsInvalid()
		{
			Assert.ThrowsException<ArgumentException>(() => ExpressionHelper.GetPropertyName<TableWithAttributes, string>(tbl => "Constant"));
			Assert.ThrowsException<ArgumentException>(() => ExpressionHelper.GetPropertyName<TableWithAttributes, string?>(tbl => null));
			Assert.ThrowsException<ArgumentException>(() => ExpressionHelper.GetPropertyName<TableWithAttributes, string?>(tbl => tbl.ToString()));

		}



	}


}