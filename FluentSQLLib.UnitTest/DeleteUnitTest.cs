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
			IDelete query;

			query = new Delete().From<TableWithoutAttributes>();
			Assert.AreEqual("TableWithoutAttributes", query.Table);
		}
		[TestMethod]
		public void Delete_ShouldSetTableFromClassWithAttributes()
		{
			IDelete query;

			query = new Delete().From<TableWithAttributes>();
			Assert.AreEqual("Table", query.Table);
		}
		#endregion

		#region Delete joined tables
		[TestMethod]
		public void Delete_ShouldAddOneJoinFromTwoClasses()
		{
			IDelete query;

			query = new Delete()
				.From<TableWithoutAttributes>()
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
			IDelete query;

			query = new Delete()
				.From<TableWithoutAttributes>()
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
			IDelete query;

			query = new Delete().From<TableWithoutAttributes>().Where(Filter.Evaluate<TableWithoutAttributes>( tbl=>tbl.Name=="Test") );
			Assert.IsNotNull(query.Filter);

			#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(() => new Delete().Where(null));
			#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}


		#endregion


	}


}