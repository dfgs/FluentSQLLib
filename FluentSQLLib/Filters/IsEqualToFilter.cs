using FluentSQLLib.Columns;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public class IsEqualToFilter: ColumnFilter, IIsEqualToFilter
	{

		public IsEqualToFilter(IColumn Column,object Value):base(Column,Value)
		{
			if (Column == null) throw new ArgumentNullException(nameof(Column));
			if (Value == null) throw new ArgumentNullException(nameof(Value));
		}

		public override string Format(string FormattedColumn, string FormattedParameter)
		{
			if (FormattedColumn == null) throw new ArgumentNullException(nameof(FormattedColumn));
			if (FormattedParameter == null) throw new ArgumentNullException(nameof(FormattedParameter));
			return $"{FormattedColumn}={FormattedParameter}";
		}

		
	}
}
