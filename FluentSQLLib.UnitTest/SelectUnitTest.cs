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

		#region select from several tables
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

		#region Where
		[TestMethod]
		public void Select_ShouldAddFilter()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Where(Filter.Evaluate<TableWithoutAttributes>( tbl=>tbl.Name=="Test") );
			Assert.IsNotNull(query.Filter);

			#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Select<TableWithoutAttributes>().Where(null));
			#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}


		#endregion

		#region select with sorts
		[TestMethod]
		public void Select_ShouldAddSortsFromClassWithoutAttributes()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID).OrderBy(tbl => tbl.Name).OrderBy(tbl => tbl.ID,OrderModes.DESC);
			Assert.AreEqual(2, query.Sorts.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Sorts.ElementAt(0).Column.Table);
			Assert.AreEqual("Name", query.Sorts.ElementAt(0).Column.Name);
			Assert.AreEqual(OrderModes.ASC, query.Sorts.ElementAt(0).OrderMode);
			Assert.AreEqual("TableWithoutAttributes", query.Sorts.ElementAt(1).Column.Table);
			Assert.AreEqual("ID", query.Sorts.ElementAt(1).Column.Name);
			Assert.AreEqual(OrderModes.DESC, query.Sorts.ElementAt(1).OrderMode);
		}
		[TestMethod]
		public void Select_ShouldAddSortsFromClassWithAttributes()
		{
			ISelect<TableWithAttributes> query;

			query = new Select<TableWithAttributes>().Column(tbl => tbl.Name).Column(tbl => tbl.ID).OrderBy(tbl=>tbl.Name).OrderBy(tbl => tbl.ID, OrderModes.DESC);
			Assert.AreEqual(2, query.Sorts.Count());
			Assert.AreEqual("Table", query.Sorts.ElementAt(0).Column.Table);
			Assert.AreEqual("colName", query.Sorts.ElementAt(0).Column.Name);
			Assert.AreEqual(OrderModes.ASC, query.Sorts.ElementAt(0).OrderMode);
			Assert.AreEqual("Table", query.Sorts.ElementAt(1).Column.Table);
			Assert.AreEqual("colID", query.Sorts.ElementAt(1).Column.Name);
			Assert.AreEqual(OrderModes.DESC, query.Sorts.ElementAt(1).OrderMode);
		}

		[TestMethod]
		public void Select_ShouldAddSortsFromSeveralTables()
		{
			ISelect<TableWithoutAttributes> query;

			query = new Select<TableWithoutAttributes>().Column(tbl => tbl.Name).Column<TableWithAttributes>(tbl => tbl.ID).OrderBy(tbl => tbl.Name).OrderBy<TableWithAttributes>(tbl => tbl.ID, OrderModes.DESC);
			Assert.AreEqual(2, query.Sorts.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Sorts.ElementAt(0).Column.Table);
			Assert.AreEqual("Name", query.Sorts.ElementAt(0).Column.Name);
			Assert.AreEqual(OrderModes.ASC, query.Sorts.ElementAt(0).OrderMode);
			Assert.AreEqual("Table", query.Sorts.ElementAt(1).Column.Table);
			Assert.AreEqual("colID", query.Sorts.ElementAt(1).Column.Name);
			Assert.AreEqual(OrderModes.DESC, query.Sorts.ElementAt(1).OrderMode);
		}
		#endregion



	}


}