using AzureTable.Provider.Configuration.Elements;

namespace AzureTable.Provider.Configuration.Mappers;

public sealed class SectionMapper<TEntity>
    where TEntity : class
{
    private readonly ElementKey<TEntity> _elementKey;

    private ContainerElement<TEntity> _containerElement;

    public void WithObject(Action<ObjectMapper<TEntity>> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        var objectMapper = new ObjectMapper<TEntity>(new ObjectElement<TEntity>());
        configure(objectMapper);
        _containerElement = objectMapper.Container;
    }

    public void WithTypedObject<TObject>(Action<TypedObjectMapper<TEntity, TObject>> configure)
        where TObject : class
    {
        ArgumentNullException.ThrowIfNull(configure);
        var typedObjectMapper = new TypedObjectMapper<TEntity, TObject>(new NamedObjectElement<TEntity>());
        configure(typedObjectMapper);
        _containerElement = typedObjectMapper.Element;
    }
}
