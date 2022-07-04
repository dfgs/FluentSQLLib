using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public class Setter<TVal> : ISetter
	{
		public IColumn Column
		{
			get;
			private set;
		}

		public TVal Value
		{
			get;
			private set;
		}

		object? ISetter.Value => Value;

		public Setter(IColumn Column,TVal Value)
		{
			if (Column== null) throw new ArgumentNullException(nameof(Column));
			this.Column = Column; 
			this.Value= Value;
		}

	}

}
