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
	public class FiltersUnitTest
	{

		#region basic filters
		[TestMethod]
		public void Filter_ShouldCheckNullParameters()
		{
			#pragma warning disable CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
			Assert.ThrowsException<ArgumentNullException>(()=> Filter.Evaluate<TableWithoutAttributes>(null));
			#pragma warning restore CS8625 // Impossible de convertir un littéral ayant une valeur null en type référence non-nullable.
		}

		[TestMethod]
		public void Filter_ShouldEvaluateIIsEqualToFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == "Test");
			Assert.IsTrue(filter is IIsEqualToFilter);
			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID == 2);
			Assert.IsTrue(filter is IIsEqualToFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsEqualToFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.Name == "Test");
			Assert.IsTrue(filter is IIsEqualToFilter);
			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID == 2);
			Assert.IsTrue(filter is IIsEqualToFilter);
		}


		[TestMethod]
		public void Filter_ShouldEvaluateIIsNotEqualToFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name != "Test");
			Assert.IsTrue(filter is IIsNotEqualToFilter);
			filter = Filter.Evaluate <TableWithoutAttributes> (tbl => tbl.ID != 2);
			Assert.IsTrue(filter is IIsNotEqualToFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsNotEqualToFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.Name != "Test");
			Assert.IsTrue(filter is IIsNotEqualToFilter);
			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID != 2);
			Assert.IsTrue(filter is IIsNotEqualToFilter);
		}

		[TestMethod]
		public void Filter_ShouldEvaluateIIsNullFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == null);
			Assert.IsTrue(filter is IIsNullFilter);
			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID == null);
			Assert.IsTrue(filter is IIsNullFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsNullFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.Name == null);
			Assert.IsTrue(filter is IIsNullFilter);
			#pragma warning disable CS0472 // Le résultat de l'expression est toujours le même, car une valeur de ce type n'est jamais égale à 'null'
			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID == null);
			#pragma warning restore CS0472 // Le résultat de l'expression est toujours le même, car une valeur de ce type n'est jamais égale à 'null'
			Assert.IsTrue(filter is IIsNullFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsNotNullFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name != null);
			Assert.IsTrue(filter is IIsNotNullFilter);
			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID != null);
			Assert.IsTrue(filter is IIsNotNullFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsNotNullFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.Name != null);
			Assert.IsTrue(filter is IIsNotNullFilter);
			#pragma warning disable CS0472 // Le résultat de l'expression est toujours le même, car une valeur de ce type n'est jamais égale à 'null'
			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID != null);
			#pragma warning restore CS0472 // Le résultat de l'expression est toujours le même, car une valeur de ce type n'est jamais égale à 'null'
			Assert.IsTrue(filter is IIsNotNullFilter);
		}


		[TestMethod]
		public void Filter_ShouldEvaluateIIsLowerThanFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID < 2);
			Assert.IsTrue(filter is IIsLowerThanFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsLowerThanFilterFromClassWithAttributes()
		{
			IFilter filter;
			
			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID < 2);
			Assert.IsTrue(filter is IIsLowerThanFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsGreaterThanFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID > 2);
			Assert.IsTrue(filter is IIsGreaterThanFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsGreaterThanFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID > 2);
			Assert.IsTrue(filter is IIsGreaterThanFilter);
		}

		[TestMethod]
		public void Filter_ShouldEvaluateIIsLowerOrEqualToFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID <= 2);
			Assert.IsTrue(filter is IIsLowerOrEqualToFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsLowerOrEqualToFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID <= 2);
			Assert.IsTrue(filter is IIsLowerOrEqualToFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsGreaterOrEqualToFilterFromClassWithoutAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID >= 2);
			Assert.IsTrue(filter is IIsGreaterOrEqualToFilter);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateIIsGreaterOrEqualToFilterFromClassWithAttributes()
		{
			IFilter filter;

			filter = Filter.Evaluate<TableWithAttributes>(tbl => tbl.ID >= 2);
			Assert.IsTrue(filter is IIsGreaterOrEqualToFilter);
		}
		#endregion

		#region filter expressions
		[TestMethod]
		public void Filter_ShouldEvaluateFilterUsingFieldAsRightMember()
		{
			IFilter filter;
			int paramID;
			string paramName;

			paramID = 2;
			paramName = "Test";

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == paramName);
			Assert.IsTrue(filter is IIsEqualToFilter);
			Assert.AreEqual("Test", ((IIsEqualToFilter)filter).Value);
			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID == paramID);
			Assert.IsTrue(filter is IIsEqualToFilter);
			Assert.AreEqual(2, ((IIsEqualToFilter)filter).Value);
		}
		private string GetString(string Value)
		{
			return Value;
		}
		private int GetInt(int Value)
		{
			return Value;
		}
		[TestMethod]
		public void Filter_ShouldEvaluateFilterUsingMethodAsRightMember()
		{
			IFilter filter;


			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == GetString("Test") ) ;
			Assert.IsTrue(filter is IIsEqualToFilter);
			Assert.AreEqual("Test", ((IIsEqualToFilter)filter).Value);
			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID == GetInt(2));
			Assert.IsTrue(filter is IIsEqualToFilter);
			Assert.AreEqual(2, ((IIsEqualToFilter)filter).Value);
		}
		[TestMethod]
		public void Filter_ShouldEvaluateFilterUsingDelegateAsRightMember()
		{
			IFilter filter;
			Func<string> delegateString;
			Func<int> delegateInt;

			delegateString = new Func<string>(() => GetString("Test"));
			delegateInt = new Func<int>(() => GetInt(2));

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == delegateString());
			Assert.IsTrue(filter is IIsEqualToFilter);
			Assert.AreEqual("Test", ((IIsEqualToFilter)filter).Value);
			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.ID == delegateInt());
			Assert.IsTrue(filter is IIsEqualToFilter);
			Assert.AreEqual(2, ((IIsEqualToFilter)filter).Value);
		}

		#endregion


		#region binary filters
		[TestMethod]
		public void Filter_ShouldEvaluateAndFilterWithTwoMembers()
		{
			IFilter filter;
			IAndFilter? andFilter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == "Test").And<TableWithAttributes>(tbl=>tbl.Name=="Test2");
			andFilter = filter as IAndFilter;
			Assert.IsNotNull(andFilter);
			Assert.AreEqual(2, andFilter.Members.Count());

		}
		[TestMethod]
		public void Filter_ShouldEvaluateAndFilterWithThreeMembers()
		{
			IFilter filter;
			IAndFilter? andFilter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == "Test").And<TableWithAttributes>(tbl => tbl.Name == "Test2").And<TableWithAttributes>(tbl => tbl.ID < 2);
			andFilter = filter as IAndFilter;
			Assert.IsNotNull(andFilter);
			Assert.AreEqual(3, andFilter.Members.Count());

		}
		[TestMethod]
		public void Filter_ShouldEvaluateOrFilterWithTwoMembers()
		{
			IFilter filter;
			IOrFilter? orFilter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == "Test").Or<TableWithAttributes>(tbl => tbl.Name == "Test2");
			orFilter = filter as IOrFilter;
			Assert.IsNotNull(orFilter);
			Assert.AreEqual(2, orFilter.Members.Count());

		}
		[TestMethod]
		public void Filter_ShouldEvaluateOrFilterWithThreeMembers()
		{
			IFilter filter;
			IOrFilter? orFilter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == "Test").Or<TableWithAttributes>(tbl => tbl.Name == "Test2").Or<TableWithAttributes>(tbl => tbl.ID < 2);
			orFilter = filter as IOrFilter;
			Assert.IsNotNull(orFilter);
			Assert.AreEqual(3, orFilter.Members.Count());

		}


		[TestMethod]
		public void Filter_ShouldEvaluateMixedFilterWithTwoMembers()
		{
			IFilter filter;
			IOrFilter? orFilter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == null).And<TableWithAttributes>(tbl => tbl.Name == "Test2").Or<TableWithoutAttributes>(tbl=>tbl.ID<2);
			orFilter = filter as IOrFilter;
			Assert.IsNotNull(orFilter);
			Assert.AreEqual(2, orFilter.Members.Count());

		}
		[TestMethod]
		public void Filter_ShouldEvaluateMixedFilterWithThreeMembers()
		{
			IFilter filter;
			IOrFilter? orFilter;

			filter = Filter.Evaluate<TableWithoutAttributes>(tbl => tbl.Name == null).And<TableWithAttributes>(tbl => tbl.Name == "Test2").Or<TableWithAttributes>(tbl => tbl.ID < 2);
			orFilter = filter as IOrFilter;
			Assert.IsNotNull(orFilter);
			Assert.AreEqual(2, orFilter.Members.Count());

		}


		#endregion

	}


}