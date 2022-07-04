using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using System.Linq.Expressions;

namespace FluentSQLLib.Queries
{
   

    public class Update<TTable> : IUpdate<TTable>
    {
        public string Table
		{
            get => Schema<TTable>.GetTableName();
		}

        private List<IJoinCondition> joinConditions;
        public IEnumerable<IJoinCondition> JoinConditions => joinConditions;
        
        private List<ISetter> setters;
        public IEnumerable<ISetter> Setters => setters;

        private IFilter? filter;
        public IFilter? Filter => filter;

        public Update()
		{
            joinConditions = new List<IJoinCondition>();
            setters = new List<ISetter>();
        }
        
       
        


        public IUpdate<TTable> Where(IFilter Filter)
        {
            if (Filter == null) throw new ArgumentNullException(nameof(Filter));
            this.filter=Filter;

            return this;
        }

        public IUpdate<TTable> Set<TValue>(Expression<Func<TTable, TValue>> Column, TValue Value)
		{
            string propertyName;
            string columnName;

            if (Column == null) throw new ArgumentNullException(nameof(Column));

            propertyName = ExpressionHelper.GetPropertyName(Column);
            columnName = Schema<TTable>.GetColumnName(propertyName);

            setters.Add(new Setter<TValue>(new Column(Schema<TTable>.GetTableName(), columnName), Value));
            return this;
        }


        public IUpdate<TTable> Join<TTable1, TTable2>(Expression<Func<TTable1, object?>> Column1, Expression<Func<TTable2, object?>> Column2)
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