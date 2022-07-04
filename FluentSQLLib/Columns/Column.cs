using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentSQLLib.Filters;

namespace FluentSQLLib.Columns
{
	public class Column:IColumn
	{
		

		public string Table
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}


		public Column(string Table, string Name)
		{
			if (Table == null) throw new ArgumentNullException(nameof(Table));
			if (Name == null) throw new ArgumentNullException(nameof(Name));
			
			this.Table = Table;
			this.Name = Name;
		}


		/*public IIsEqualToFilter<TVal> IsEqualTo(TVal Value)
		{
			return new IsEqualToFilter<TVal>(this, Value);
		}
		public IIsNotEqualToFilter<TVal> IsNotEqualTo(TVal Value)
		{
			return new IsNotEqualToFilter<TVal>(this, Value);
		}
		public IIsGreaterThanFilter<TVal> IsGreaterThan(TVal Value)
		{
			return new IsGreaterThanFilter<TVal>(this, Value);
		}
		public IIsLowerThanFilter<TVal> IsLowerThan(TVal Value)
		{
			return new IsLowerThanFilter<TVal>(this, Value);
		}
		public IIsGreaterOrEqualToFilter<TVal> IsGreaterOrEqualTo(TVal Value)
		{
			return new IsGreaterOrEqualToFilter<TVal>(this, Value);
		}
		public IIsLowerOrEqualToFilter<TVal> IsLowerOrEqualTo(TVal Value)
		{
			return new IsLowerOrEqualToFilter<TVal>(this, Value);
		}
		public IIsNullFilter IsNull()
		{
			return new IsNullFilter(this);
		}
		public IIsNotNullFilter IsNotNull()
		{
			return new IsNotNullFilter(this);
		}*/

		public override string ToString()
		{
			return Name;
		}

		/*public void Initialize(ISingleTable Table,string Name)
		{
			this.Table = Table;
			if (this.Name==null) this.Name = Name;
		}*/

	}
}
