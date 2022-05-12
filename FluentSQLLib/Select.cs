using System.Linq.Expressions;

namespace FluentSQLLib
{
    public static class Select
    {
        public static Select<T> From<T>()
        {
            return new Select<T>();
        }
    }

	public class Select<T>:Query,ISelect
	{
        public string TableName
		{
            get;
            private set;
		}
        public Select<T> Column<TColumn>(Expression<Func<T, TColumn>> ValueExpression)
        {
            /*var columnName = SpryExpression.GetColumnName(valueExpression);
            var value = SpryExpression.GetColumnValue(valueExpression);
            InsertValueImpl(columnName, value);
            return this;*/
            return this;

        }

     


    }
}