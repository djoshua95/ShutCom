using System.Linq.Expressions;

namespace MysticMadness.Service.Generics;

public struct OrderByOptions<TEntity>
{
    public Expression<Func<TEntity, object>> Selector { get; set; }
    public bool Descending { get; set; }
}
