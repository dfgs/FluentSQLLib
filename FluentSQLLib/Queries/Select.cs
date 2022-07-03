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
            object? defaultValue;
            Type dataType;

            propertyName=ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<T>.GetColumnName(propertyName);
            dataType = Schema<T>.GetDataType(propertyName);
            isNullable =Schema<T>.GetIsNullable(propertyName);
            defaultValue = Schema<T>.GetDefaultValue(propertyName);

            columns.Add(new Column(this.table, columnName, dataType, defaultValue,ColumnConstraints.None,false,isNullable));

            return this;

        }
        public ISelect<T> AllColumns()
        {
            string columnName;
            bool isNullable;
            object? defaultValue;
            Type dataType;

            foreach (string propertyName in Schema<T>.GetProperties())
            {
                columnName = Schema<T>.GetColumnName(propertyName);
                dataType = Schema<T>.GetDataType(propertyName);
                isNullable = Schema<T>.GetIsNullable(propertyName);
                defaultValue = Schema<T>.GetDefaultValue(propertyName);

                columns.Add(new Column(this.table,columnName, dataType, defaultValue, ColumnConstraints.None, false, isNullable));
            }

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