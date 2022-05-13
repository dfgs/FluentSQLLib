using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public abstract class BooleanFilter : IBooleanFilter
	{
		private List<IFilter> members;
		public IEnumerable<IFilter> Members => members;

		public BooleanFilter(params IFilter[] Members)
		{
			if  ((Members==null) || (Members.Length < 2)) throw new ArgumentException("Boolean filter must constain at least 2 members");
			this.members=new List<IFilter>(Members);
		}

		public abstract string Format(IEnumerable<string> FormattedMembers);

		public void Add(IFilter Filter)
		{
			if (Filter==null) throw new ArgumentNullException(nameof(Filter));
			members.Add(Filter);
		}

		public abstract IAndFilter And(IFilter Filter);
		public abstract IOrFilter Or(IFilter Filter);
	}
}
