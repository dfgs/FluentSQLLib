using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using FluentSQLLib.Tables;
using System.Linq.Expressions;

namespace FluentSQLLib.Queries
{
   

    public class Delete : IDelete
    {
        private string? table;
        public string? Table
		{
            get => table;
            private set => table = value;
		}

        private List<IJoinCondition> joinConditions;
        public IEnumerable<IJoinCondition> JoinConditions => joinConditions;

        private IFilter? filter;
        public IFilter? Filter => filter;

        public Delete()
		{
            joinConditions = new List<IJoinCondition>();
        }
        
       
        public IDelete From<TTable>()
        {
            this.table = Schema<TTable>.GetTableName();
            return this;
        }


        public IDelete Where(IFilter Filter)
        {
            if (Filter == null) throw new ArgumentNullException(nameof(Filter));
            this.filter=Filter;

            return this;
        }
       

        
        public IDelete Join<TTable1, TTable2>(Expression<Func<TTable1, object?>> Column1, Expression<Func<TTable2, object?>> Column2)
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