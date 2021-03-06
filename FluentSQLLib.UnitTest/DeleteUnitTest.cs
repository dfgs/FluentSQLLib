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
	public class DeleteUnitTest
	{

		#region Delete 
		[TestMethod]
		public void Delete_ShouldSetTableFromClassWithoutAttributes()
		{
			IDelete<TableWithoutAttributes> query;

			query = new Delete<TableWithoutAttributes>();
			Assert.AreEqual("TableWithoutAttributes", query.Table);
		}
		[TestMethod]
		public void Delete_ShouldSetTableFromClassWithAttributes()
		{
			IDelete<TableWithAttributes> query;

			query = new Delete<TableWithAttributes>();
			Assert.AreEqual("Table", query.Table);
		}
		#endregion

		#region Delete joined tables
		[TestMethod]
		public void Delete_ShouldAddOneJoinFromTwoClasses()
		{
			IDelete<TableWithoutAttributes> query;

			query = new Delete<TableWithoutAttributes>()
				.Join<TableWithoutAttributes, TableWithAttributes>(tbl1=>tbl1.ID,tbl2=>tbl2.ID);
			Assert.AreEqual(1, query.JoinConditions.Count());
			Assert.AreEqual("TableWithoutAttributes", query.JoinConditions.ElementAt(0).Column1.Table);
			Assert.AreEqual("ID", query.JoinConditions.ElementAt(0).Column1.Name);
			Assert.AreEqual("Table", query.JoinConditions.ElementAt(0).Column2.Table);
			Assert.AreEqual("colID", query.JoinConditions.ElementAt(0).Column2.Name);
		}
		[TestMethod]
		public void Delete_ShouldAddTwoJoinsFromTwoClasses()
		{
			IDelete<TableWithoutAttributes> query;

			query = new Delete<TableWithoutAttributes>()
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
		public void Delete_ShouldAddFilter()
		{
			IDelete<TableWithoutAttributes> query;

			query = new Delete<TableWithoutAttributes>().Where(Filter.Evaluate<TableWithoutAttributes>( tbl=>tbl.Name=="Test") );
			Assert.IsNotNull(query.Filter);

			#pragma warning disable CS8625 // Impossible de convertir un litt?ral ayant une valeur null en type r?f?rence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Delete<TableWithoutAttributes>().Where(null));
			#pragma warning restore CS8625 // Impossible de convertir un litt?ral ayant une valeur null en type r?f?rence non-nullable.
		}


		#endregion


	}


}