using FluentSQLLib.Columns;
using FluentSQLLib.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib
{
	public static class ExpressionHelper
	{
        private static object? GetValue(Expression Member)
        {
            var objectMember = Expression.Convert(Member, typeof(object));

            var getterLambda = Expression.Lambda<Func<object>>(objectMember);

            var getter = getterLambda.Compile();

            return getter();
        }
       
        private static object? GetConstant(Expression Expression)
        {
            if (Expression == null) throw new ArgumentNullException(nameof(Expression));

            switch (Expression)
            {
                case InvocationExpression invocationExpression:
                    return GetValue(invocationExpression);
                case MethodCallExpression methodExpression:
                    return GetValue(methodExpression);
                 case MemberExpression memberExpression:
                    return GetValue(memberExpression);
                case ConstantExpression constantExpression:
                    return constantExpression.Value;
                case UnaryExpression unaryExpression:
                    switch (unaryExpression.NodeType)
                    {
                        case ExpressionType.Convert:
                            return GetConstant(unaryExpression.Operand);
                        default: throw new ArgumentException($"Invalid expression: {Expression.ToString()}, constant expected");
                    }
                default: throw new ArgumentException($"Invalid expression: {Expression.ToString()}, constant expected");
            }
        }
        private static string GetMember(Expression Expression)
        {
            if (Expression == null) throw new ArgumentNullException(nameof(Expression));

            switch (Expression)
            {
                case MemberExpression memberExpression:
                    return memberExpression.Member.Name;
                case UnaryExpression unaryExpression:
                    switch (unaryExpression.NodeType)
                    {
                        case ExpressionType.Convert:
                            return GetMember(unaryExpression.Operand);
                        default: throw new ArgumentException($"Invalid expression: {Expression.ToString()}, member expected");
                    }
                default: throw new ArgumentException($"Invalid expression: {Expression.ToString()}, member expected");
            }
        }
       
        public static string GetPropertyName<T,TVal>(Expression<Func<T, TVal>> Expression)
        {
            if (Expression==null) throw new ArgumentNullException(nameof(Expression));
            return GetMember(Expression.Body);
        }

       
        public static IFilter GetFilter<T>(Expression<Func<T, bool>> Expression)
        {
            string propertyName;
            object? value;
            IFilter filter;
            IColumn column;


            if (Expression == null) throw new ArgumentNullException(nameof(Expression));
            
            if (!(Expression.Body is BinaryExpression binaryExpression)) throw new ArgumentException($"Invalid expression: {Expression.ToString()}, binary expression expected");

            
            switch(binaryExpression.NodeType)
			{
               case ExpressionType.Equal:
                    propertyName = GetMember(binaryExpression.Left);
                    column = new Column(Schema<T>.GetTableName(), propertyName);
                    value = ExpressionHelper.GetConstant(binaryExpression.Right);
                    if (value == null) filter = new IsNullFilter(column);
                    else filter = new IsEqualToFilter(column, value);
                    break;
                case ExpressionType.NotEqual:
                    propertyName = GetMember(binaryExpression.Left);
                    column = new Column(Schema<T>.GetTableName(), propertyName);
                    value = ExpressionHelper.GetConstant(binaryExpression.Right);
                    if (value == null) filter = new IsNotNullFilter(column);
                    else filter = new IsNotEqualToFilter(column, value);
                    break;
                case ExpressionType.LessThan:
                    propertyName = GetMember(binaryExpression.Left);
                    column = new Column(Schema<T>.GetTableName(), propertyName);
                    value = ExpressionHelper.GetConstant(binaryExpression.Right);
                    if (value == null) throw new ArgumentException($"Invalid expression (Right): {Expression.ToString()}, non null value expected");
                    else filter = new IsLowerThanFilter(column, value);
                    break;
                case ExpressionType.GreaterThan:
                    propertyName = GetMember(binaryExpression.Left);
                    column = new Column(Schema<T>.GetTableName(), propertyName);
                    value = ExpressionHelper.GetConstant(binaryExpression.Right);
                    if (value == null) throw new ArgumentException($"Invalid expression (Right): {Expression.ToString()}, non null value expected");
                    else filter = new IsGreaterThanFilter(column, value);
                    break;
                case ExpressionType.LessThanOrEqual:
                    propertyName = GetMember(binaryExpression.Left);
                    column = new Column(Schema<T>.GetTableName(), propertyName);
                    value = ExpressionHelper.GetConstant(binaryExpression.Right);
                    if (value == null) throw new ArgumentException($"Invalid expression (Right): {Expression.ToString()}, non null value expected");
                    else filter = new IsLowerOrEqualToFilter(column, value);
                    break;
                case ExpressionType.GreaterThanOrEqual:
                    propertyName = GetMember(binaryExpression.Left);
                    column = new Column(Schema<T>.GetTableName(), propertyName);
                    value = ExpressionHelper.GetConstant(binaryExpression.Right);
                    if (value == null) throw new ArgumentException($"Invalid expression (Right): {Expression.ToString()}, non null value expected");
                    else filter = new IsGreaterOrEqualToFilter(column, value);
                    break;

                default: throw new ArgumentException($"Invalid expression (Operator): {Expression.ToString()}, operator expected");
            }
                    
            return filter;

        }



    }
}
