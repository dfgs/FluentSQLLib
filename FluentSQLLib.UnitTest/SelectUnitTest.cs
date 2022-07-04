using FluentSQLLib.Filters;
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
		#region GetTableName
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
		#endregion

		#region select columns
		[TestMethod]
		public void Select_ShouldAddColumnsFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("ID", query.Columns.ElementAt(1).Name);
		}
		[TestMethod]
		public void Select_ShouldAddColumnsFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("Table", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
		}



		[TestMethod]
		public void Select_ShouldAddAllColumnsFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().AllColumns();
			Assert.AreEqual(4, query.Columns.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("ID", query.Columns.ElementAt(1).Name);
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(2).Table);
			Assert.AreEqual("Description", query.Columns.ElementAt(2).Name);
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(3).Table);
			Assert.AreEqual("NullID", query.Columns.ElementAt(3).Name);
		}
		[TestMethod]
		public void Select_ShouldAddAllColumnsFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().AllColumns();
			Assert.AreEqual(4, query.Columns.Count());
			Assert.AreEqual("Table", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(2).Table);
			Assert.AreEqual("colDescription", query.Columns.ElementAt(2).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(3).Table);
			Assert.AreEqual("colNullID", query.Columns.ElementAt(3).Name);
		}
		#endregion

		#region select joined tables
		[TestMethod]
		public void Select_ShouldAddColumnsFromTwoClasses()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name)
				.Column<TableWithAttributes>(tbl => tbl.Name);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(1).Name);
		}


		[TestMethod]
		public void Select_ShouldAddAllColumnsFromJoinedTable()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().AllColumns<TableWithAttributes>();
			Assert.AreEqual(4, query.Columns.Count());
			Assert.AreEqual("Table", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(2).Table);
			Assert.AreEqual("colDescription", query.Columns.ElementAt(2).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(3).Table);
			Assert.AreEqual("colNullID", query.Columns.ElementAt(3).Name);
		}


		#endregion

		#region filters
		[TestMethod]
		public void Select_ShouldAddIIsEqualToFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl=>tbl.Name=="Test");
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsEqualToFilter);
			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID == 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsEqualToFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsEqualToFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name == "Test");
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsEqualToFilter);
			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID == 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsEqualToFilter);
		}


		[TestMethod]
		public void Select_ShouldAddIIsNotEqualToFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name != "Test");
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotEqualToFilter);
			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID != 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotEqualToFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsNotEqualToFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name != "Test");
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotEqualToFilter);
			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID != 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotEqualToFilter);
		}

		[TestMethod]
		public void Select_ShouldAddIIsNullFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name == null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNullFilter);
			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID == null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNullFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsNullFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name == null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNullFilter);
			// expected warning
			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID == null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNullFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsNotNullFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name != null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotNullFilter);
			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID != null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotNullFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsNotNullFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.Name != null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotNullFilter);
			// expected warning
			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID != null);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsNotNullFilter);
		}


		[TestMethod]
		public void Select_ShouldAddIIsLowerThanFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID < 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsLowerThanFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsLowerThanFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID < 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsLowerThanFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsGreaterThanFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID > 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsGreaterThanFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsGreaterThanFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID > 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsGreaterThanFilter);
		}

		[TestMethod]
		public void Select_ShouldAddIIsLowerOrEqualToFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID <= 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsLowerOrEqualToFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsLowerOrEqualToFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID <= 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsLowerOrEqualToFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsGreaterOrEqualToFilterFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID >= 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsGreaterOrEqualToFilter);
		}
		[TestMethod]
		public void Select_ShouldAddIIsGreaterOrEqualToFilterFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Where(tbl => tbl.ID >= 2);
			Assert.AreEqual(1, query.Filters.Count());
			Assert.IsTrue(query.Filters.ElementAt(0) is IIsGreaterOrEqualToFilter);
		}
		#endregion


	}


}