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
	public class UpdateUnitTest
	{

		#region Update 
		[TestMethod]
		public void Update_ShouldSetTableFromClassWithoutAttributes()
		{
			IUpdate<TableWithoutAttributes> query;

			query = new Update<TableWithoutAttributes>();
			Assert.AreEqual("TableWithoutAttributes", query.Table);
		}
		[TestMethod]
		public void Update_ShouldSetTableFromClassWithAttributes()
		{
			IUpdate<TableWithAttributes> query;

			query = new Update<TableWithAttributes>();
			Assert.AreEqual("Table", query.Table);
		}
		public void Update_ShouldAddSettersFromClassWithoutAttributes()
		{
			IUpdate<TableWithoutAttributes> query;

			query = new Update<TableWithoutAttributes>().Set(tbl=>tbl.Name,"test").Set(tbl=>tbl.ID,2);
			Assert.AreEqual(2, query.Setters.Count());
			Assert.AreEqual("TableWithoutAttributes", query.Setters.ElementAt(0).Column.Table);
			Assert.AreEqual("Name", query.Setters.ElementAt(0).Column.Name);
			Assert.AreEqual("TableWithoutAttributes", query.Setters.ElementAt(1).Column.Table);
			Assert.AreEqual("ID", query.Setters.ElementAt(1).Column.Name);
		}
		[TestMethod]
		public void Update_ShouldAddSettersFromClassWithAttributes()
		{
			IUpdate<TableWithAttributes> query;

			query = new Update<TableWithAttributes>().Set(tbl => tbl.Name, "test").Set(tbl => tbl.ID, 2);
			Assert.AreEqual("Table", query.Table);
			Assert.AreEqual(2, query.Setters.Count());
			Assert.AreEqual("Table", query.Setters.ElementAt(0).Column.Table);
			Assert.AreEqual("colName", query.Setters.ElementAt(0).Column.Name);
			Assert.AreEqual("Table", query.Setters.ElementAt(1).Column.Table);
			Assert.AreEqual("colID", query.Setters.ElementAt(1).Column.Name);
		}
		#endregion

		#region Update joined tables
		[TestMethod]
		public void Update_ShouldAddOneJoinFromTwoClasses()
		{
			IUpdate<TableWithoutAttributes> query;

			query = new Update<TableWithoutAttributes>()
				.Join<TableWithoutAttributes, TableWithAttributes>(tbl1=>tbl1.ID,tbl2=>tbl2.ID);
			Assert.AreEqual(1, query.JoinConditions.Count());
			Assert.AreEqual("TableWithoutAttributes", query.JoinConditions.ElementAt(0).Column1.Table);
			Assert.AreEqual("ID", query.JoinConditions.ElementAt(0).Column1.Name);
			Assert.AreEqual("Table", query.JoinConditions.ElementAt(0).Column2.Table);
			Assert.AreEqual("colID", query.JoinConditions.ElementAt(0).Column2.Name);
		}
		[TestMethod]
		public void Update_ShouldAddTwoJoinsFromTwoClasses()
		{
			IUpdate<TableWithoutAttributes> query;

			query = new Update<TableWithoutAttributes>()
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
		public void Update_ShouldAddFilter()
		{
			IUpdate<TableWithoutAttributes> query;

			query = new Update<TableWithoutAttributes>().Where(Filter.Evaluate<TableWithoutAttributes>( tbl=>tbl.Name=="Test") );
			Assert.IsNotNull(query.Filter);

			#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Update<TableWithoutAttributes>().Where(null));
			#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}


		#endregion


	}


}