using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using FluentSQLLib.Tables;
using System.Linq.Expressions;

namespace FluentSQLLib.Queries
{
   

    public class Select<T> : ISelect<T>
    {

      

        public int Limit
        {
            get;
            private set;
        }

        private ITable table;
        public ITable Table => table;

        private List<IColumn> columns;
        public IEnumerable<IColumn> Columns => columns;

        private List<ISort> sorts;
        public IEnumerable<ISort> Sorts => sorts;

        private IFilter? filter;
        public IFilter? Filter => filter;

        public Select()
		{
            this.table = new Table(Schema<T>.GetTableName());
            Limit = -1;
            columns = new List<IColumn>();
            sorts = new List<ISort>();
        }




       


        public ISelect<T> Column(Expression<Func<T, object?>> ValueExpression)
        {
            string propertyName;
            string columnName;

            propertyName = ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<T>.GetColumnName(propertyName);

            columns.Add(new Column(this.table.Name, columnName));

            return this;

        }
        public ISelect<T> Column<TTable>(Expression<Func<TTable, object?>> ValueExpression)
        {
            string propertyName;
            string columnName;

            propertyName = ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<TTable>.GetColumnName(propertyName);

            columns.Add(new Column(Schema<TTable>.GetTableName(), columnName));

            return this;

        }


        public ISelect<T> AllColumns()
        {
            string columnName;

            foreach (string propertyName in Schema<T>.GetProperties())
            {
                columnName = Schema<T>.GetColumnName(propertyName);

                columns.Add(new Column(this.table.Name, columnName));
            }

            return this;

        }
        public ISelect<T> AllColumns<TTable>()
        {
            string columnName;

            foreach (string propertyName in Schema<TTable>.GetProperties())
            {
                columnName = Schema<TTable>.GetColumnName(propertyName);

                columns.Add(new Column(Schema<TTable>.GetTableName(), columnName));
            }
            return this;
        }

        public ISelect<T> Where(IFilter Filter)
        {
            if (Filter == null) throw new ArgumentNullException(nameof(Filter));
            this.filter=Filter;

            return this;
        }
        

        
        public ISelect<T> OrderBy(Expression<Func<T, object?>> ValueExpression, OrderModes OrderMode=OrderModes.ASC)
        {
            string propertyName;
            string columnName;

            if (ValueExpression == null) throw new ArgumentNullException(nameof(ValueExpression));

            propertyName = ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<T>.GetColumnName(propertyName);

            sorts.Add(new Sort(new Column(Schema<T>.GetTableName(), columnName), OrderMode));
            return this;
        }
       
        public ISelect<T> OrderBy<TTable>(Expression<Func<TTable, object?>> ValueExpression, OrderModes OrderMode = OrderModes.ASC)
        {
            string propertyName;
            string columnName;

            if (ValueExpression == null) throw new ArgumentNullException(nameof(ValueExpression));

            propertyName = ExpressionHelper.GetPropertyName(ValueExpression);
            columnName = Schema<TTable>.GetColumnName(propertyName);

            sorts.Add(new Sort(new Column(Schema<TTable>.GetTableName(), columnName), OrderMode));
            return this;
        }

        public ISelect<T> Top(int Limit)
        {
            this.Limit = Limit;
            return this;
        }


    }
}