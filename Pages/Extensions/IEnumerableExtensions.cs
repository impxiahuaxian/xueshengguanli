using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Objects;
namespace MVC
{
    public static class IEnumerableExtensions
    {
        //默认排序
        //默认排序
        //public static PagedList<T> ToPagedList<T>
        //     (
        //         this IEnumerable<T> allItems,
        //         int pageIndex,
        //         int pageSize
        //     )
        //{
        //    //var list = allItems as IOrderedQueryable;
        //    //return GetPagedList(allItems, pageIndex, pageSize);
        //    if (allItems is IOrderedEnumerable<T> || allItems is IOrderedQueryable<T>)
        //    {
        //        return GetPagedList(allItems, pageIndex, pageSize);
        //    }
        //    else
        //    {
        //        SortColumn sc = new SortColumn();
        //        sc.DescAsc = DescAsc.Asc;
        //        sc.ColumnName = "ID";
        //        if (allItems == null)
        //            allItems = new List<T>();
        //        var list = SortByColumn(allItems, sc);//默认排序
        //        return GetPagedList(list, pageIndex, pageSize);
        //    }
        //}
        public static PagedList<T> ToPagedList<T>
             (
                 this IOrderedQueryable<T> allItems,
                 int pageIndex,
                 int pageSize
             )
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize);
            var totalItemCount = allItems.Count();
            return new PagedList<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
            //return GetPagedList<T>(allItems, pageIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>
            (
                this IOrderedQueryable<T> allItems,
                int pageIndex,
                int pageSize,
                int itemCount
            )
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var pageOfItems = allItems;

            var totalItemCount = itemCount;
            return new PagedList<T>(pageOfItems, pageIndex, pageSize, totalItemCount, true);
            //return GetPagedList<T>(allItems, pageIndex, pageSize);
        }

        //public static PagedList<T> GetPagedList<T>(IOrderedQueryable<T> allItems,
        //       int pageIndex,
        //       int pageSize)
        //{
        //    IOrderedQueryable<T> list =null;
        //    if (allItems is IOrderedQueryable<T> && !(allItems is ObjectQuery<T>) )
        //    {
        //        list = allItems as IOrderedQueryable<T>;
        //    }
        //    else
        //    {
        //        list = SortByColumn<T>(allItems, new SortColumn { ColumnName="ID", DescAsc= DescAsc.Desc });
        //    }

        //    if (pageIndex < 1)
        //        pageIndex = 1;
        //    var itemIndex = (pageIndex - 1) * pageSize;
        //    var pageOfItems = list.Skip(itemIndex).Take(pageSize);
        //    var totalItemCount = list.Count();
        //    return new PagedList<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
        //}

        ////默认排序
        //public static IOrderedEnumerable<T> SortByColumn<T>(IEnumerable<T> source, SortColumn sc)
        //{
        //    var item = Expression.Parameter(typeof(T), "item");//添加参数，对象
        //    var propertyValue = Expression.PropertyOrField(item, sc.ColumnName);//对象属性
        //    var propertyLambda = Expression.Lambda(propertyValue, item);//得到lambda表达式
        //    // item => item.{columnName}

        //    var sourceExpression = Expression.Parameter(typeof(IEnumerable<T>), "source");//添加参数，对象IEnumerable列表

        //    string methodName;
        //    Expression inputExpression;

        //    methodName = sc.DescAsc == DescAsc.Asc ? "OrderBy" : "OrderByDescending";
        //    inputExpression = sourceExpression;

        //    var sortTypeParameters = new Type[] { typeof(T), propertyValue.Type };//排序的 对象类型
        //    var sortExpression = Expression.Call(typeof(Enumerable), methodName, sortTypeParameters, inputExpression, propertyLambda);//生成lambda表达式
        //    var sortLambda = Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(sortExpression, sourceExpression);
        //    // source => IEnumerable.OrderBy<T, TKey>(source, item => item.{columnName})

        //    return sortLambda.Compile()(source);//执行lambda方法排序，得到返回值
        //}

        public static IOrderedQueryable<T> SortByColumn<T>(this IQueryable<T> source, SortColumn sc)
        {
            var item = Expression.Parameter(typeof(T), "item");//添加参数，对象
            var propertyValue = Expression.PropertyOrField(item, sc.ColumnName);//对象属性
            var propertyLambda = Expression.Lambda(propertyValue, item);//得到lambda表达式
            // item => item.{columnName}

            var sourceExpression = Expression.Parameter(typeof(IQueryable<T>), "source");//添加参数，对象IEnumerable列表

            string methodName;
            Expression inputExpression;

            methodName = sc.DescAsc == DescAsc.Asc ? "OrderBy" : "OrderByDescending";
            inputExpression = sourceExpression;

            var sortTypeParameters = new Type[] { typeof(T), propertyValue.Type };//排序的 对象类型
            var sortExpression = Expression.Call(typeof(Queryable), methodName, sortTypeParameters, inputExpression, propertyLambda);//生成lambda表达式
            var sortLambda = Expression.Lambda<Func<IQueryable<T>, IOrderedQueryable<T>>>(sortExpression, sourceExpression);
            // source => IEnumerable.OrderBy<T, TKey>(source, item => item.{columnName})

            return sortLambda.Compile()(source);//执行lambda方法排序，得到返回值
        }

        //默认排序
        public static IOrderedEnumerable<T> SortByColumn<T>(IEnumerable<T> source, List<SortColumn> scList)
        {
            if (scList.Count < 1)
            {
                throw new Exception("属性至少为一个");
            }
            var item = Expression.Parameter(typeof(T), "item");//添加参数，对象
            var propertyValue = Expression.PropertyOrField(item, scList[0].ColumnName);//对象属性
            var propertyLambda = Expression.Lambda(propertyValue, item);//得到lambda表达式
            // item => item.{columnName}

            var sourceExpression = Expression.Parameter(typeof(IEnumerable<T>), "source");//添加参数，对象IEnumerable列表
            IOrderedEnumerable<T> OrderedSource = null;
            string methodName = "OrderBy";
            Expression inputExpression = null;
            for (int i = 0; i < scList.Count; i++)
            {
                if (i == 0)
                {
                    methodName = scList[0].DescAsc == DescAsc.Asc ? "OrderBy" : "OrderByDescending";
                    inputExpression = sourceExpression;
                    var sortTypeParameters = new Type[] { typeof(T), propertyValue.Type };//排序的 对象类型
                    var sortExpression = Expression.Call(typeof(Enumerable), methodName, sortTypeParameters, inputExpression, propertyLambda);//生成lambda表达式
                    var sortLambda = Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(sortExpression, sourceExpression);
                    OrderedSource = sortLambda.Compile()(source);
                }
                else
                {
                    methodName = scList[0].DescAsc == DescAsc.Asc ? "ThenBy" : "ThenByDescending";//倒序或正序
                    inputExpression = Expression.Convert(sourceExpression, typeof(IOrderedEnumerable<T>));
                    // ThenBy requires input to be IOrderedEnumerable<T>
                    var sortTypeParameters = new Type[] { typeof(T), propertyValue.Type };//排序的 对象类型
                    var sortExpression = Expression.Call(typeof(Enumerable), methodName, sortTypeParameters, inputExpression, propertyLambda);//生成lambda表达式
                    var sortLambda = Expression.Lambda<Func<IEnumerable<T>, IOrderedEnumerable<T>>>(sortExpression, sourceExpression);
                    OrderedSource = sortLambda.Compile()(OrderedSource);
                }
            }
            return OrderedSource;//执行lambda方法排序，得到返回值
        }


    }
}
