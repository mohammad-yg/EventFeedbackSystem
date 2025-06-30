namespace EventFeedbackSystem.Application.Shared.Exctenstions;

public static class QueryExtenstions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Func<IQueryable<T>, IQueryable<T>> predicate)
    {
        return condition ? predicate(query) : query;
    }

    public static IQueryable<T> OrderByIf<T>(this IQueryable<T> query, bool condition, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
    {
        return condition ? orderBy(query) : (IOrderedQueryable<T>)query;
    }

    public static IQueryable<T> SkipIf<T>(this IQueryable<T> query, bool condition, int count)
    {
        return condition ? query.Skip(count) : query;
    }
}
