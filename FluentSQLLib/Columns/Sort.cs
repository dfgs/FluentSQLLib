using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public class Sort : ISort
	{
		public IColumn Column
		{
			get;
			private set;
		}

		public OrderModes OrderMode
		{
			get;
			private set;
		}

		public Sort(IColumn Column,OrderModes OrderMode)
		{
			if (Column== null) throw new ArgumentNullException(nameof(Column));
			this.Column = Column; 
			this.OrderMode= OrderMode;
		}

	}

}
