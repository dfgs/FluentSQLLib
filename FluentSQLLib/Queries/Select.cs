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
            bool isNullable;
            TVal? defaultValue;

            propertyName=ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<T>.GetColumnName(propertyName);
            isNullable=Schema<T>.GetIsNullable(propertyName);
            defaultValue = (TVal?)Schema<T>.GetDefaultValue(propertyName);

            columns.Add(new Column<TVal>(this.table,columnName,defaultValue,ColumnConstraints.None,false,isNullable));

            return this;

        }

       

        public ISelect<T> Where(params IFilter[] Filters)
        {
            if (Filters == null) throw new ArgumentNullException(nameof(Filters));
            filters.AddRange(Filters);
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