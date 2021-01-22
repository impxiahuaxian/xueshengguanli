using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq.SqlClient;
using System.Collections.Generic;

namespace MVC.Linq
{
    public static class QueryBuilder
    {
        public static IQueryBuilder<T> Create<T>()
        {
            return new QueryBuilder<T>();
        }
    }

    class QueryBuilder<T> : IQueryBuilder<T>
    {
        private Expression<Func<T, bool>> predicate;
        Expression<Func<T, bool>> IQueryBuilder<T>.Expression
        {
            get
            {
                return predicate;
            }
            set
            {
                predicate = value;
            }
        }

        public QueryBuilder()
        {
            predicate = PredicateBuilder.True<T>();
        }
    }

    /// <summary>
    /// 动态查询条件创建者
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryBuilder<T>
    {
        Expression<Func<T, bool>> Expression { get; set; }
    }

    public static class IQueryBuilderExtensions
    {
        /// <summary>
        /// 建立 Between 查询条件,为空则不查（包括边界值）
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="q">动态查询条件创建者</param>
        /// <param name="property">属性</param>
        /// <param name="from">开始值,可为空</param>
        /// <param name="to">结束值,可为空</param>
        /// <returns></returns>
        public static IQueryBuilder<T> Between<T, P>(this IQueryBuilder<T> q, Expression<Func<T, P>> property, P from, P to)
        {
            //if (from == null || to == null)
            //    return q;
            var parameter = property.GetParameters();
            var constantFrom = Expression.Constant(from);
            var constantTo = Expression.Constant(to); 
            Type type = typeof(P);
            Expression nonNullProperty = property.Body;
            //如果是Nullable<X>类型，则转化成X类型
            if (IsNullableType(type))
            {
                type = GetNonNullableType(type);
                nonNullProperty = Expression.Convert(property.Body, type);
            }
            //var c = Expression.AndAlso(c1, c2);
            BinaryExpression c = null;
            if (to != null)
            {
                c = Expression.LessThanOrEqual(nonNullProperty, constantTo);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(c, parameter);
                q.Expression = q.Expression.And(lambda);
            }
            if (from != null)
            {
                c = Expression.GreaterThanOrEqual(nonNullProperty, constantFrom);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(c, parameter);
                q.Expression = q.Expression.And(lambda);
            }
            return q;
        }

        /// <summary>
        /// 建立 Like ( 模糊 ) 查询条件
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="q">动态查询条件创建者</param>
        /// <param name="property">属性</param>
        /// <param name="value">查询值</param>
        /// <returns></returns>
        public static IQueryBuilder<T> Like<T>(this IQueryBuilder<T> q, Expression<Func<T, string>> property, string value)
        {
            value = value==null?"":value.Trim();
            if (string.IsNullOrEmpty(value))
                return q;
            if (!string.IsNullOrEmpty(value))
            {
                var parameter = property.GetParameters();
                var constant = Expression.Constant("%" + value + "%");
                //MethodCallExpression methodExp = Expression.Call(null, typeof(SqlMethods).GetMethod("Like",
                //    new Type[] { typeof(string), typeof(string) }), property.Body, constant);
                MethodCallExpression methodExp = Expression.Call(null, typeof(SqlMethods).GetMethod("Like",
                    new Type[] { typeof(string), typeof(string) }), property.Body, constant);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);

                q.Expression = q.Expression.And(lambda);
            }
            return q;
        }

        /// <summary>
        /// 建立 Equals ( 相等 ) 查询条件
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="q">动态查询条件创建者</param>
        /// <param name="property">属性</param>
        /// <param name="value">查询值</param>
        /// <returns></returns>
        public static IQueryBuilder<T> Equals<T, P>(this IQueryBuilder<T> q, Expression<Func<T, P>> property, P value)
        {
            if (value==null)
                return q;
            var parameter = property.GetParameters();
            var constant = Expression.Constant(value);
            Type type = typeof(P);
            Expression nonNullProperty = property.Body;
            //如果是Nullable<X>类型，则转化成X类型
            if (IsNullableType(type)) 
            {
                type = GetNonNullableType(type);
                nonNullProperty = Expression.Convert(property.Body, type);
            }
            var methodExp = Expression.Equal(nonNullProperty, constant);
            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
            q.Expression = q.Expression.And(lambda);
            return q;
        }

        /// <summary>
        /// 建立 In 查询条件
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="q">动态查询条件创建者</param>
        /// <param name="property">属性</param>
        /// <param name="valuse">查询值</param> 
        /// <returns></returns>
        public static IQueryBuilder<T> In<T,P>(this IQueryBuilder<T> q, Expression<Func<T, P>> property, params P[] values)
        {
            if (values != null && values.Length > 0)
            {
                var parameter = property.GetParameters();
                var constant = Expression.Constant(values);
                Type type = typeof(P);
                Expression nonNullProperty = property.Body;
                //如果是Nullable<X>类型，则转化成X类型
                if (IsNullableType(type))
                {
                    type = GetNonNullableType(type);
                    nonNullProperty = Expression.Convert(property.Body, type);
                }
                Expression<Func<P[], P, bool>> InExpression = (list, el) => list.Contains(el);
                var methodExp = InExpression;
                var invoke = Expression.Invoke(methodExp, constant, property.Body);
                Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(invoke, parameter);
                q.Expression = q.Expression.And(lambda);
            }
            return q;
        }

        private static ParameterExpression[] GetParameters<T, S>(this Expression<Func<T, S>> expr)
        {
            return expr.Parameters.ToArray();
        }

        static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        static Type GetNonNullableType(Type type)
        {
            return type.GetGenericArguments()[0];
            //return IsNullableType(type) ? type.GetGenericArguments()[0] : type;
        }

        #region 废弃的代码

        //private static readonly DateTime minDate = new DateTime(1800, 1, 1);
        //private static readonly DateTime maxDate = new DateTime(2999, 1, 1);

        ///// <summary>
        ///// 建立 Between 查询条件
        ///// </summary>
        ///// <typeparam name="T">实体</typeparam>
        ///// <param name="q">动态查询条件创建者</param>
        ///// <param name="property">属性</param>
        ///// <param name="from">开始值</param>
        ///// <param name="to">结束值</param>
        ///// <returns></returns>
        //public static IQueryBuilder<T> Between<T>(this IQueryBuilder<T> q, Expression<Func<T, DateTime>> property, DateTime from, DateTime to)
        //{
        //    if (from < minDate)
        //        from = minDate;
        //    if (to > maxDate)
        //        to = maxDate;
        //    else
        //        to = to.AddDays(1).AddSeconds(-1); 
        //    if (!(from == minDate && to == maxDate))
        //    {
        //        var parameter = property.GetParameters();
        //        var constantFrom = Expression.Constant(from);
        //        var constantTo = Expression.Constant(to);
        //        var value = property.Body;
        //        var c1 = Expression.GreaterThanOrEqual(value, constantFrom);
        //        var c2 = Expression.LessThanOrEqual(value, constantTo);
        //        var c = Expression.AndAlso(c1, c2);
        //        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(c, parameter);

        //        q.Expression = q.Expression.And(lambda);
        //    }
        //    return q;
        //}

        ///// <summary>
        ///// 建立 Between 查询条件
        ///// </summary>
        ///// <typeparam name="T">实体</typeparam>
        ///// <param name="q">动态查询条件创建者</param>
        ///// <param name="property">属性</param>
        ///// <param name="from">开始值</param>
        ///// <param name="to">结束值</param>
        ///// <returns></returns>
        //public static IQueryBuilder<T> Between<T>(this IQueryBuilder<T> q, Expression<Func<T, DateTime?>> property, DateTime from, DateTime to)
        //{
        //    if (from < minDate)
        //        from = minDate;
        //    if (to > maxDate)
        //        to = maxDate;
        //    else
        //        to = to.AddDays(1).AddSeconds(-1);
        //    if (!(from == minDate && to == maxDate))
        //    {
        //        var parameter = property.GetParameters();
        //        var constantFrom = Expression.Constant(from);
        //        var constantTo = Expression.Constant(to);
        //        var value = Expression.Convert(property.Body, typeof(DateTime));
        //        var c1 = Expression.GreaterThanOrEqual(value, constantFrom);
        //        var c2 = Expression.LessThanOrEqual(value, constantTo);
        //        var c = Expression.AndAlso(c1, c2);
        //        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(c, parameter);

        //        q.Expression = q.Expression.And(lambda);
        //    }
        //    return q;
        //}

        ///// <summary>
        ///// 建立 Between 查询条件
        ///// </summary>
        ///// <typeparam name="T">实体</typeparam>
        ///// <param name="q">动态查询条件创建者</param>
        ///// <param name="property">属性</param>
        ///// <param name="from">开始值</param>
        ///// <param name="to">结束值</param>
        ///// <returns></returns>
        //public static IQueryBuilder<T> Between<T>(this IQueryBuilder<T> q, Expression<Func<T, string>> property, string from, string to)
        //{
        //    from = from.Trim();
        //    to = to.Trim();
        //    if (from == string.Empty && to == string.Empty)
        //        return q;
        //    if (from.CompareTo(to) <= 0)
        //    {
        //        var parameter = property.GetParameters();
        //        var constantFrom = Expression.Constant(from);
        //        var constantTo = Expression.Constant(to);
        //        var constantZero = Expression.Constant(0);
        //        var compareMethod = typeof(string).GetMethod("Compare", new Type[] { typeof(string), typeof(string) });
        //        MethodCallExpression methodExp1 = Expression.Call(null, compareMethod, property.Body, constantFrom);
        //        var c1 = Expression.GreaterThanOrEqual(methodExp1, constantZero);
        //        MethodCallExpression methodExp2 = Expression.Call(null, compareMethod, property.Body, constantTo);
        //        var c2 = Expression.LessThanOrEqual(methodExp2, constantZero);
        //        var c = Expression.AndAlso(c1, c2);
        //        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(c, parameter);

        //        q.Expression = q.Expression.And(lambda);
        //    }
        //    return q;
        //}

        //private static Expression<Func<string[], string, bool>> InExpression = (list, el) => list.Contains(el);

        ///// <summary>
        ///// 建立 In 查询条件
        ///// </summary>
        ///// <typeparam name="T">实体</typeparam>
        ///// <param name="q">动态查询条件创建者</param>
        ///// <param name="property">属性</param>
        ///// <param name="valuse">查询值</param> 
        ///// <returns></returns>
        //public static IQueryBuilder<T> In<T>(this IQueryBuilder<T> q, Expression<Func<T, string>> property, params string[] values)
        //{
        //    if (values != null && values.Length > 0)
        //    {
        //        var parameter = property.GetParameters();
        //        var constant = Expression.Constant(values);
        //        var methodExp = InExpression;  
        //        var invoke = Expression.Invoke(methodExp, constant, property.Body);
        //        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(invoke, parameter);
        //        q.Expression = q.Expression.And(lambda);
        //    }
        //    return q;
        //} 

        //public static IQueryBuilder<T> Custom<T>(this IQueryBuilder<T> q, Expression<Func<T, bool>> expression)
        //{
        //    q.Expression = q.Expression.And(expression);
        //    return q;
        //}

        ///// <summary>
        ///// 建立 Equals ( 相等 ) 查询条件
        ///// </summary>
        ///// <typeparam name="T">实体</typeparam>
        ///// <param name="q">动态查询条件创建者</param>
        ///// <param name="property">属性</param>
        ///// <param name="value">查询值</param>
        ///// <returns></returns>
        //public static IQueryBuilder<T> Equals<T>(this IQueryBuilder<T> q, Expression<Func<T, string>> property, string value)
        //{
        //    var parameter = property.GetParameters(); 
        //    var constant = Expression.Constant(value);
        //    MethodCallExpression methodExp = Expression.Call(null, typeof(string).GetMethod("Equals",
        //        new Type[] { typeof(string), typeof(string) }), property.Body, constant);
        //    Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
        //    q.Expression = q.Expression.And(lambda);
        //    return q;
        //}

        ///// <summary>
        ///// 建立 Equals ( 相等 ) 查询条件
        ///// </summary>
        ///// <typeparam name="T">实体</typeparam>
        ///// <param name="q">动态查询条件创建者</param>
        ///// <param name="property">属性</param>
        ///// <param name="value">查询值</param>
        ///// <param name="exclude">排除值（意味着如果value==exclude，则当前条件不被包含到查询中）</param>
        ///// <returns></returns>
        //public static IQueryBuilder<T> Equals<T>(this IQueryBuilder<T> q, Expression<Func<T, string>> property, string value, string exclude)
        //{
        //    if (value != exclude)
        //    {
        //        var parameter = property.GetParameters();
        //        var constant = Expression.Constant(value);
        //        MethodCallExpression methodExp = Expression.Call(null, typeof(string).GetMethod("Equals",
        //            new Type[] { typeof(string), typeof(string) }), property.Body, constant);
        //        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
        //        q.Expression = q.Expression.And(lambda);
        //    }
        //    return q;
        //}

        #endregion

    }

}
