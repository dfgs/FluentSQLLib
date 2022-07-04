using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Columns
{
	public class JoinCondition : IJoinCondition
	{
		public IColumn Column1
		{
			get;
			private set;
		}
		public IColumn Column2
		{
			get;
			private set;
		}

		public JoinCondition(IColumn Column1, IColumn Column2)
		{
			this.Column1 = Column1;this.Column2= Column2; 
		}

	}
}
