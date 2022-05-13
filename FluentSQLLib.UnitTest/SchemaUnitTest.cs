using FluentSQLLib.UnitTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FluentSQLLib.UnitTest
{
	[TestClass]
	public class SchemaUnitTest
	{

		#region GetTableName
		[TestMethod]
		public void Schema_ShouldGetTableNameFromClassWithoutAttributes()
		{
			Assert.AreEqual("TableWithoutAttributes", Schema<TableWithoutAttributes>.GetTableName());

		}
		[TestMethod]
		public void Schema_ShouldGetTableNameFromClassWithAttributes()
		{
			Assert.AreEqual("Table", Schema<TableWithAttributes>.GetTableName());

		}
		#endregion

		#region GetColumnName
#nullable disable
		[TestMethod]
		public void GetColumnName_ShouldCheckNullParameter()
		{
			Assert.ThrowsException<ArgumentNullException>(() => Schema<TableWithAttributes>.GetColumnName(null));
			Assert.ThrowsException<ArgumentNullException>(() => Schema<TableWithoutAttributes>.GetColumnName(null));

		}
#nullable restore
		[TestMethod]
		public void GetColumnName_ShouldThrowErrorIfPropertyNameIsNotFound()
		{
			Assert.ThrowsException<KeyNotFoundException>(() => Schema<TableWithAttributes>.GetColumnName("invalidName"));
			Assert.ThrowsException<KeyNotFoundException>(() => Schema<TableWithoutAttributes>.GetColumnName("invalidName"));
		}
		[TestMethod]
		public void GetColumnName_ShouldReturnPropertyNameByDefault()
		{
			Assert.AreEqual("Name", Schema<TableWithoutAttributes>.GetColumnName("Name"));
			Assert.AreEqual("ID", Schema<TableWithoutAttributes>.GetColumnName("ID"));
		}

		[TestMethod]
		public void GetColumnName_ShouldReturnUserDefinedName()
		{
			Assert.AreEqual("colName", Schema<TableWithAttributes>.GetColumnName("Name"));
			Assert.AreEqual("colID", Schema<TableWithAttributes>.GetColumnName("ID"));
		}
		#endregion

		#region GetDefaultValue
#nullable disable
		[TestMethod]
		public void GetDefaultValue_ShouldCheckNullParameter()
		{
			Assert.ThrowsException<ArgumentNullException>(() => Schema<TableWithAttributes>.GetDefaultValue(null));
			Assert.ThrowsException<ArgumentNullException>(() => Schema<TableWithoutAttributes>.GetDefaultValue(null));

		}
#nullable restore
		[TestMethod]
		public void GetDefaultValue_ShouldThrowErrorIfPropertyNameIsNotFound()
		{
			Assert.ThrowsException<KeyNotFoundException>(() => Schema<TableWithAttributes>.GetDefaultValue("invalidName"));
			Assert.ThrowsException<KeyNotFoundException>(() => Schema<TableWithoutAttributes>.GetDefaultValue("invalidName"));
		}
		[TestMethod]
		public void GetDefaultValue_ShouldReturnNullByDefault()
		{
			Assert.AreEqual(null, Schema<TableWithoutAttributes>.GetDefaultValue("Name"));
			Assert.AreEqual(null, Schema<TableWithoutAttributes>.GetDefaultValue("ID"));
		}

		[TestMethod]
		public void GetDefaultValue_ShouldReturnUserDefinedValue()
		{
			Assert.AreEqual("Homer", Schema<TableWithAttributes>.GetDefaultValue("Name"));
			Assert.AreEqual(12, Schema<TableWithAttributes>.GetDefaultValue("ID"));
		}
		#endregion

		#region GetIsNullable
#nullable disable
		[TestMethod]
		public void GetIsNullable_ShouldCheckNullParameter()
		{
			Assert.ThrowsException<ArgumentNullException>(() => Schema<TableWithAttributes>.GetIsNullable(null));
			Assert.ThrowsException<ArgumentNullException>(() => Schema<TableWithoutAttributes>.GetIsNullable(null));

		}
#nullable restore
		[TestMethod]
		public void GetIsNullable_ShouldThrowErrorIfPropertyNameIsNotFound()
		{
			Assert.ThrowsException<KeyNotFoundException>(() => Schema<TableWithAttributes>.GetIsNullable("invalidName"));
			Assert.ThrowsException<KeyNotFoundException>(() => Schema<TableWithoutAttributes>.GetIsNullable("invalidName"));
		}
		[TestMethod]
		public void GetIsNullable_ShouldReturnFalse()
		{
			Assert.AreEqual(false, Schema<TableWithAttributes>.GetIsNullable("Name"));
			Assert.AreEqual(false, Schema<TableWithAttributes>.GetIsNullable("ID"));
		}
		[TestMethod]
		public void GetIsNullable_ShouldReturnTrue()
		{
			Assert.AreEqual(true, Schema<TableWithoutAttributes>.GetIsNullable("Name"));
			Assert.AreEqual(true, Schema<TableWithoutAttributes>.GetIsNullable("ID"));
			Assert.AreEqual(true, Schema<TableWithoutAttributes>.GetIsNullable("Description"));
			Assert.AreEqual(true, Schema<TableWithoutAttributes>.GetIsNullable("NullID"));
			Assert.AreEqual(true, Schema<TableWithAttributes>.GetIsNullable("Description"));
			Assert.AreEqual(true, Schema<TableWithAttributes>.GetIsNullable("NullID"));
		}

		#endregion


	}


}