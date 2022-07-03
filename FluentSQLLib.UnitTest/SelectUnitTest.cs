using FluentSQLLib.Queries;
using FluentSQLLib.UnitTest.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentSQLLib.UnitTest
{
	[TestClass]
	public class SelectUnitTest
	{
		[TestMethod]
		public void Select_ShouldGetTableNameFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

		
			query=new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID);
			Assert.AreEqual("TableWithoutAttributes", query.Table.Name);
		}

		[TestMethod]
		public void Select_ShouldGetTableNameFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID);
			Assert.AreEqual("Table", query.Table.Name);
		}




		[TestMethod]
		public void Select_ShouldAddColumnsFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("ID", query.Columns.ElementAt(1).Name);
		}
		[TestMethod]
		public void Select_ShouldAddColumnsFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
		}



		[TestMethod]
		public void Select_ShouldAddAllColumnsFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().AllColumns();
			Assert.AreEqual(4, query.Columns.Count());
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("ID", query.Columns.ElementAt(1).Name);
			Assert.AreEqual("Description", query.Columns.ElementAt(2).Name);
			Assert.AreEqual("NullID", query.Columns.ElementAt(3).Name);
		}
		[TestMethod]
		public void Select_ShouldAddAllColumnsFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().AllColumns();
			Assert.AreEqual(4, query.Columns.Count());
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
			Assert.AreEqual("colDescription", query.Columns.ElementAt(2).Name);
			Assert.AreEqual("colNullID", query.Columns.ElementAt(3).Name);
		}



	}


}