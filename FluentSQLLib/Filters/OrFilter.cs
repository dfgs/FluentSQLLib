using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib.Filters
{
	public class OrFilter : BooleanFilter, IOrFilter
	{
		
		public OrFilter(params IFilter[] Members):base(Members)
		{
			if (Members == null) throw new ArgumentNullException(nameof(Members));
		}

		

		public override string Format(IEnumerable<string> FormattedMembers)
		{
			if (FormattedMembers == null) throw new ArgumentNullException(nameof(FormattedMembers));
			return $"({String.Join(" OR ", FormattedMembers)})";
		}
		public  override IAndFilter And(IFilter Filter)
		{
			if (Filter == null) throw new ArgumentNullException(nameof(Filter));
			if (Filter is IAndFilter other)
			{
				other.Add(this);
				return other;
			}
			else
			{
				return new AndFilter(this, Filter);
			}
		}
		public override IOrFilter Or(IFilter Filter)
		{
			if (Filter == null) throw new ArgumentNullException(nameof(Filter));
			if (Filter is IOrFilter other)
			{
				foreach (IFilter item in other.Members) Add(item);
				return this;
			}
			else
			{
				Add(Filter);
				return this;
			}
		}
	}
}
