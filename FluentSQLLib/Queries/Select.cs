using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using FluentSQLLib.Tables;
using System.Linq.Expressions;

namespace FluentSQLLib.Queries
{
   

    public class Select<T> : ISelect<T>
    {

        public OrderModes OrderMode
        {
            get;
            private set;
        }

        public int Limit
        {
            get;
            private set;
        }

        private ITable table;
        public ITable Table => table;

        private List<IColumn> columns;
        public IEnumerable<IColumn> Columns => columns;

        private List<IColumn> orders;
        public IEnumerable<IColumn> Orders => orders;

        private List<IFilter> filters;
        public IEnumerable<IFilter> Filters => filters;

        public Select()
		{
            this.table = new Table(Schema<T>.GetTableName());
            Limit = -1;
            columns = new List<IColumn>();
            filters = new List<IFilter>();
            orders = new List<IColumn>();
        }




       


        public ISelect<T> Column<TVal>(Expression<Func<T, TVal>> ValueExpression)
        {
            string propertyName;
            string columnName;

            propertyName = ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<T>.GetColumnName(propertyName);

            columns.Add(new Column(this.table.Name, columnName));

            return this;

        }
        public ISelect<T> AllColumns()
        {
            string columnName;

            foreach (string propertyName in Schema<T>.GetProperties())
            {
                columnName = Schema<T>.GetColumnName(propertyName);

                columns.Add(new Column(this.table.Name,columnName));
            }

            return this;

        }

        public ISelect<T> Where(Expression<Func<T, bool>> FilterExpression)
        {
            IFilter filter;

            filter = ExpressionHelper.GetFilter(FilterExpression);
            filters.Add(filter);

            return this;
        }


        public ISelect<T> OrderBy(params IColumn[] Columns)
        {
            if (Columns == null) throw new ArgumentNullException(nameof(Columns));
            return OrderBy(OrderModes.ASC, Columns);
        }
        public ISelect<T> OrderBy(OrderModes OrderMode, params IColumn[] Columns)
        {
            if (Columns == null) throw new ArgumentNullException(nameof(Columns));
            this.OrderMode = OrderMode;
            orders.AddRange(Columns);
            return this;
        }

        public ISelect<T> Top(int Limit)
        {
            this.Limit = Limit;
            return this;
        }


    }
}