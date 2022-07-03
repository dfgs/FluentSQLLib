using FluentSQLLib.Attributes;
using FluentSQLLib.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DefaultValueAttribute = FluentSQLLib.Attributes.DefaultValueAttribute;

namespace FluentSQLLib
{
	public static class Schema<T>
	{
		private static NullabilityInfoContext nullabilityContext;


		static Schema()
		{
			nullabilityContext = new NullabilityInfoContext();

		}
		private static PropertyInfo? GetProperty(string PropertyName)
		{
			Type type;

			if (PropertyName == null) throw new ArgumentNullException(nameof(PropertyName));

			type = typeof(T);
			return type.GetProperty(PropertyName);
		}

		private static TAttribute? GetAttribute<TAttribute>(string PropertyName)
			where TAttribute:System.Attribute
		{
			PropertyInfo? pi;

			if (PropertyName == null) throw new ArgumentNullException(nameof(PropertyName));

			pi = GetProperty(PropertyName);
			if (pi == null) throw new KeyNotFoundException($"Property {PropertyName} was not found in table {GetTableName()}");
			return pi.GetCustomAttribute<TAttribute>(true);
		}

		public static IEnumerable<string> GetProperties()
		{
			Type type;

			type = typeof(T);

			return type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(item => item.Name);
		}

		public static string GetTableName()
		{
			Type type;
			TableNameAttribute? tableNameAttribute;

			type = typeof(T);

			tableNameAttribute = type.GetCustomAttribute<TableNameAttribute>(true);
			return tableNameAttribute?.Value ?? type.Name;
		}


		public static string GetColumnName(string PropertyName)
		{
			if (PropertyName == null) throw new ArgumentNullException(nameof(PropertyName));
			return GetAttribute<ColumnNameAttribute>(PropertyName)?.Value ?? PropertyName;
		}
		public static object? GetDefaultValue(string PropertyName)
		{
			if (PropertyName == null) throw new ArgumentNullException(nameof(PropertyName));
			return GetAttribute<DefaultValueAttribute>(PropertyName)?.Value ?? null;
		}

		public static bool GetIsNullable(string PropertyName)
		{
			if (PropertyName == null) throw new ArgumentNullException(nameof(PropertyName));
			PropertyInfo? pi;
			
			pi = GetProperty(PropertyName);
			if (pi == null) throw new KeyNotFoundException($"Property {PropertyName} was not found in table {GetTableName()}");

			var nullabilityInfo = nullabilityContext.Create(pi);

			return (nullabilityInfo.WriteState is NullabilityState.Nullable) || (Nullable.GetUnderlyingType(pi.PropertyType)!=null);
		}

		public static Type GetDataType(string PropertyName)
		{
			if (PropertyName == null) throw new ArgumentNullException(nameof(PropertyName));
			PropertyInfo? pi;

			pi = GetProperty(PropertyName);
			if (pi == null) throw new KeyNotFoundException($"Property {PropertyName} was not found in table {GetTableName()}");


			return pi.PropertyType;
		}


	}
}
