using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentSQLLib
{
	public static class ExpressionHelper
	{
        public static string GetPropertyName<T, TVal>(Expression<Func<T, TVal>> Expression)
        {
            if (Expression==null) throw new ArgumentNullException(nameof(Expression));

            switch(Expression.Body)
			{
                case MemberExpression memberExpression: return memberExpression.Member.Name;
                /*case ConstantExpression constantExpression:
                    string? result = constantExpression?.Value?.ToString();
                    if (result == null) throw new ArgumentException("Invalid expression");
                    return result;*/
                default:throw new ArgumentException("Invalid expression"); 
			}
        }


    }
}
