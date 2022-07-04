using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using System.Linq.Expressions;

namespace FluentSQLLib.Queries
{
   

    public class Select : ISelect
    {

      

        public int Limit
        {
            get;
            private set;
        }

        

        private List<IColumn> columns;
        public IEnumerable<IColumn> Columns => columns;

        private List<ISort> sorts;
        public IEnumerable<ISort> Sorts => sorts;

        private List<IJoinCondition> joinConditions;
        public IEnumerable<IJoinCondition> JoinConditions => joinConditions;

        private IFilter? filter;
        public IFilter? Filter => filter;

        public Select()
		{
            Limit = -1;
            columns = new List<IColumn>();
            sorts = new List<ISort>();
            joinConditions = new List<IJoinCondition>();
        }




       


       
        public ISelect From<TTable>(params Expression<Func<TTable, object?>>[] Columns)
        {
            string propertyName;
            string columnName;
            
            if (Columns == null) throw new ArgumentNullException(nameof(Columns));

            foreach (Expression<Func<TTable, object?>> expression in Columns)
            {
                propertyName = ExpressionHelper.GetPropertyName(expression);
                columnName = Schema<TTable>.GetColumnName(propertyName);

                columns.Add(new Column(Schema<TTable>.GetTableName(), columnName));
            }
            return this;

        }

        public ISelect AllFrom<TTable>()
        {
            string columnName;

            foreach (string propertyName in Schema<TTable>.GetProperties())
            {
                columnName = Schema<TTable>.GetColumnName(propertyName);

                columns.Add(new Column(Schema<TTable>.GetTableName(), columnName));
            }
            return this;
        }

        public ISelect Where(IFilter Filter)
        {
            if (Filter == null) throw new ArgumentNullException(nameof(Filter));
            this.filter=Filter;

            return this;
        }
        
               
        public ISelect OrderBy<TTable>(Expression<Func<TTable, object?>> Column, OrderModes OrderMode = OrderModes.ASC)
        {
            string propertyName;
            string columnName;

            if (Column == null) throw new ArgumentNullException(nameof(Column));

            propertyName = ExpressionHelper.GetPropertyName(Column);
            columnName = Schema<TTable>.GetColumnName(propertyName);

            sorts.Add(new Sort(new Column(Schema<TTable>.GetTableName(), columnName), OrderMode));
            return this;
        }

        public ISelect Top(int Limit)
        {
            this.Limit = Limit;
            return this;
        }

        public ISelect Join<TTable1, TTable2>(Expression<Func<TTable1, object?>> Column1, Expression<Func<TTable2, object?>> Column2)
		{
            string propertyName1;
            string columnName1;
            string propertyName2;
            string columnName2;
            IJoinCondition joinCondition;

            if (Column1 == null) throw new ArgumentNullException(nameof(Column1));
            if (Column2 == null) throw new ArgumentNullException(nameof(Column2));

            propertyName1 = ExpressionHelper.GetPropertyName(Column1);
            columnName1 = Schema<TTable1>.GetColumnName(propertyName1);
            propertyName2 = ExpressionHelper.GetPropertyName(Column2);
            columnName2 = Schema<TTable2>.GetColumnName(propertyName2);

            joinCondition = new JoinCondition(new Column(Schema<TTable1>.GetTableName(), columnName1), new Column(Schema<TTable2>.GetTableName(), columnName2));
            joinConditions.Add(joinCondition);
            return this;
		}


    }
}