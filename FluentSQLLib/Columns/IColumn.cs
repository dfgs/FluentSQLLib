
using FluentSQLLib.Filters;
using FluentSQLLib.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public interface IColumn
	{
		string Name
		{
			get;
		}

		ITable Table
		{
			get;
		}
			   
		ColumnConstraints Constraint
		{
			get;
		}

		bool IsNullable
		{
			get;
		}

		Type DataType
		{
			get;
		}

		bool IsIdentity
		{
			get;
		}

		object? DefaultValue
		{
			get;
		}
		//void Initialize(ISingleTable Table,string Name);
		/*object GetValue(IRow Row);
		void SetValue(IRow Row,object Value);*/
	}

	public interface IColumn<TVal>:IColumn
	{
		

		/*IIsNullFilter IsNull();
		IIsNotNullFilter IsNotNull();
		
		IIsEqualToFilter<TVal> IsEqualTo(TVal Value);
		IIsNotEqualToFilter< TVal> IsNotEqualTo(TVal Value);
		IIsGreaterThanFilter<TVal> IsGreaterThan(TVal Value);
		IIsLowerThanFilter<TVal> IsLowerThan(TVal Value);
		IIsGreaterOrEqualToFilter<TVal> IsGreaterOrEqualTo(TVal Value);
		IIsLowerOrEqualToFilter<TVal> IsLowerOrEqualTo(TVal Value);//*/

	}//*/

}
