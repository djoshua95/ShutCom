using MysticMadness.Service.Generics;

namespace MysticMadness.Service.Utils;

public static class QueryableExtensions
{
    /// <summary>
    /// Applies sorting to the given <see cref="IQueryable{TEntity}"/> based on the specified sorting options.
    /// </summary>
    /// <typeparam name="TEntity">The type of the elements in the source query.</typeparam>
    /// <param name="source">The source query to which sorting will be applied.</param>
    /// <param name="keySelectors">
    /// An array of <see cref="OrderByOptions{TEntity}"/> specifying the sorting criteria. 
    /// Each option includes a selector function and a flag indicating whether the sorting should be descending.
    /// </param>
    /// <returns>
    /// A sorted <see cref="IQueryable{TEntity}"/> based on the provided sorting options. 
    /// If no sorting options are provided, the original source query is returned.
    /// </returns>
    /// <remarks>
    /// The first sorting option is applied using <see cref="Queryable.OrderBy{TSource, TKey}"/> or 
    /// <see cref="Queryable.OrderByDescending{TSource, TKey}"/>. Subsequent sorting options are applied using 
    /// <see cref="Queryable.ThenBy{TSource, TKey}"/> or <see cref="Queryable.ThenByDescending{TSource, TKey}"/>.
    /// </remarks>
    /// <example>
    /// <code>
    /// var sortedQuery = query.ApplySorting(
    ///     new OrderByOptions<MyEntity> { Selector = x => x.Name, Descending = false },
    ///     new OrderByOptions<MyEntity> { Selector = x => x.Age, Descending = true }
    /// );
    /// </code>
    /// </example>
    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> source, params OrderByOptions<TEntity>[] keySelectors)
    {
        if (keySelectors == null || keySelectors.Length == 0)
            return source;

        var first = keySelectors.First();
        var sortedQuery = first.Descending
            ? source.OrderByDescending(first.Selector)
            : source.OrderBy(first.Selector);

        foreach (var keySelector in keySelectors[1..])
        {
            sortedQuery = keySelector.Descending
                ? sortedQuery.ThenByDescending(keySelector.Selector)
                : sortedQuery.ThenBy(keySelector.Selector);
        }

        return sortedQuery;
    }
}
