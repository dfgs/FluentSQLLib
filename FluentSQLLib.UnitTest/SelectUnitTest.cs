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

		#region select columns
		[TestMethod]
		public void Select_ShouldAddColumnsFromClassWithoutAttributes()
		{
			ISelect query;

			query = new Select().From<TableWithoutAttributes>(tbl => tbl.Name).From<TableWithoutAttributes>(tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("ID", query.Columns.ElementAt(1).Name);

			query = new Select().From<TableWithoutAttributes>(tbl => tbl.Name, tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("ID", query.Columns.ElementAt(1).Name);
		}
		[TestMethod]
		public void Select_ShouldAddColumnsFromClassWithAttributes()
		{
			ISelect query;

			query = new Select().From<TableWithAttributes>(tbl => tbl.Name).From<TableWithAttributes>(tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("Table", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
			
			query = new Select().From<TableWithAttributes>(tbl => tbl.Name, tbl => tbl.ID);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("Table", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colID", query.Columns.ElementAt(1).Name);
		}



		[TestMethod]
		public void Select_ShouldAddAllFromFromClassWithoutAttributes()
		{
			ISelect query;

			query = new Select().AllFrom<TableWithoutAttributes>();
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
		public void Select_ShouldAddAllFromFromClassWithAttributes()
		{
			ISelect query;

			query = new Select().AllFrom<TableWithAttributes>();
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
			ISelect query;

			query = new Select().From<TableWithoutAttributes>(tbl => tbl.Name)
				.From<TableWithAttributes>(tbl => tbl.Name);
			Assert.AreEqual(2, query.Columns.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Columns.ElementAt(0).Table);
			Assert.AreEqual("Name", query.Columns.ElementAt(0).Name);
			Assert.AreEqual("Table", query.Columns.ElementAt(1).Table);
			Assert.AreEqual("colName", query.Columns.ElementAt(1).Name);
		}


		[TestMethod]
		public void Select_ShouldAddAllFromFromJoinedTable()
		{
			ISelect query;

			query = new Select().AllFrom<TableWithAttributes>();
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
		public void Select_ShouldAddOneJoinFromTwoClasses()
		{
			ISelect query;

			query = new Select()
				.From<TableWithoutAttributes>(tbl => tbl.Name)
				.From<TableWithAttributes>(tbl => tbl.Name)
				.Join<TableWithoutAttributes, TableWithAttributes>(tbl1=>tbl1.ID,tbl2=>tbl2.ID);
			Assert.AreEqual(1, query.JoinConditions.Count());
			Assert.AreEqual("TableWithoutAttributes", query.JoinConditions.ElementAt(0).Column1.Table);
			Assert.AreEqual("ID", query.JoinConditions.ElementAt(0).Column1.Name);
			Assert.AreEqual("Table", query.JoinConditions.ElementAt(0).Column2.Table);
			Assert.AreEqual("colID", query.JoinConditions.ElementAt(0).Column2.Name);
		}
		[TestMethod]
		public void Select_ShouldAddTwoJoinsFromTwoClasses()
		{
			ISelect query;

			query = new Select()
				.From<TableWithoutAttributes>(tbl => tbl.Name)
				.From<TableWithAttributes>(tbl => tbl.Name)
				.Join<TableWithoutAttributes, TableWithAttributes>(tbl1 => tbl1.ID, tbl2 => tbl2.ID)
				.Join<TableWithoutAttributes, TableWithAttributes>(tbl1 => tbl1.Name, tbl2 => tbl2.Name);
			Assert.AreEqual(2, query.JoinConditions.Count());
			
			Assert.AreEqual("TableWithoutAttributes", query.JoinConditions.ElementAt(0).Column1.Table);
			Assert.AreEqual("ID", query.JoinConditions.ElementAt(0).Column1.Name);
			Assert.AreEqual("Table", query.JoinConditions.ElementAt(0).Column2.Table);
			Assert.AreEqual("colID", query.JoinConditions.ElementAt(0).Column2.Name);

			Assert.AreEqual("TableWithoutAttributes", query.JoinConditions.ElementAt(1).Column1.Table);
			Assert.AreEqual("Name", query.JoinConditions.ElementAt(1).Column1.Name);
			Assert.AreEqual("Table", query.JoinConditions.ElementAt(1).Column2.Table);
			Assert.AreEqual("colName", query.JoinConditions.ElementAt(1).Column2.Name);

		}




		#endregion

		#region Where
		[TestMethod]
		public void Select_ShouldAddFilter()
		{
			ISelect query;

			query = new Select().From<TableWithoutAttributes>(tbl => tbl.Name).Where(Filter.Evaluate<TableWithoutAttributes>( tbl=>tbl.Name=="Test") );
			Assert.IsNotNull(query.Filter);

			#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Select().Where(null));
			#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}


		#endregion

		#region select with sorts
		[TestMethod]
		public void Select_ShouldAddSortsFromClassWithoutAttributes()
		{
			ISelect query;

			query = new Select().From<TableWithoutAttributes>(tbl => tbl.Name).From<TableWithoutAttributes>(tbl => tbl.ID).OrderBy<TableWithoutAttributes>(tbl => tbl.Name).OrderBy<TableWithoutAttributes>(tbl => tbl.ID,OrderModes.DESC);
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
			ISelect query;

			query = new Select().From<TableWithAttributes>(tbl => tbl.Name).From<TableWithAttributes>(tbl => tbl.ID).OrderBy<TableWithAttributes>(tbl=>tbl.Name).OrderBy<TableWithAttributes>(tbl => tbl.ID, OrderModes.DESC);
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
			ISelect query;

			query = new Select().From<TableWithoutAttributes>(tbl => tbl.Name).From<TableWithAttributes>(tbl => tbl.ID).OrderBy<TableWithoutAttributes>(tbl => tbl.Name).OrderBy<TableWithAttributes>(tbl => tbl.ID, OrderModes.DESC);
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