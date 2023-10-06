using System.Linq.Expressions;
using System.Reflection;

namespace EmailMarketing.Architecture.Helpers
{
    public static class QueryHelper
    {
        public static IQueryable<TEntity> FiltrarPaginado<TEntity>(this IQueryable<TEntity> consulta, int start, int length, string sortColumn = "", string sortColumnDirection = "asc") where TEntity : class
        {
            if (length == 0) length = 10;
            if (sortColumn is null) sortColumn = string.Empty;
            if (sortColumnDirection is null) sortColumnDirection = string.Empty;


            if (sortColumn is null)
            {
                consulta.AsQueryable().Skip(start).Take(length);
            }

            return consulta.AsQueryable().OrderByCustom(sortColumn, sortColumnDirection).Skip(start).Take(length);
        }
        public static IOrderedQueryable<T> OrderByCustom<T>(this IQueryable<T> source, string property, string direction)
        {
            if (direction == "asc")
            {
                return ApplyOrder<T>(source, property, "OrderBy");
            }

            return ApplyOrder<T>(source, property, "OrderByDescending");

        }

        static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;

            foreach (string prop in props)
            {
                var properties = typeof(T).GetProperties();
                foreach (var propValue in properties)
                {
                    if (propValue.Name.ToLower().Equals(prop.ToLower()))
                    {
                        PropertyInfo pi = type.GetProperty(propValue.Name);
                        expr = Expression.Property(expr, pi);
                        type = pi.PropertyType;
                        break;
                    }
                }
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                method => method.Name == methodName
                    && method.IsGenericMethodDefinition
                    && method.GetGenericArguments().Length == 2
                    && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<T>)result;
        }
    }
}
