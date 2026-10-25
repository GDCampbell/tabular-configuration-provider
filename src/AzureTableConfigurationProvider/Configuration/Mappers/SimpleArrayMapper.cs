using AzureTable.Provider.Configuration.Elements;
using System.Linq.Expressions;

namespace AzureTable.Provider.Configuration.Mappers;

public sealed class SimpleArrayMapper<TEntity, TValue>
    where TEntity : class
{
    internal SimpleArrayElement<TEntity> Element { get; }

    internal SimpleArrayMapper(string name)
        => Element = new(name);

    internal SimpleArrayMapper(Expression<Func<TEntity, string>> nameExpression)
        => Element = new(nameExpression);

    public SimpleArrayMapper<TEntity, TValue> AddItem(Func<TEntity, TValue> itemFactory)
    {
        ArgumentNullException.ThrowIfNull(itemFactory);
        Element.Add(itemFactory);
        return this;
    }
}
