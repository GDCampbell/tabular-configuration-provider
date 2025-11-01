using AzureTable.Provider.Configuration.Mapping.Elements;
using System.Linq.Expressions;

namespace AzureTable.Provider.Configuration.Mapping;

public static class ConfigurationMapperObjectExtensions
{
    public static TMapper AddObject<T, TMapper>(this TMapper mapper, string name, Action<ObjectMapper<T>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(configure);

        return mapper.AddObject(new NamedObjectElement<T>(name), configure);
    }

    public static TMapper AddObject<T, TMapper>(this TMapper mapper, Expression<Func<T, string>> nameExpression, Action<ObjectMapper<T>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentNullException.ThrowIfNull(nameExpression);
        ArgumentNullException.ThrowIfNull(configure);

        return mapper.AddObject(new NamedObjectElement<T>(nameExpression), configure);
    }

    public static TMapper AddTypedObject<T, TMapper, TObject>(this TMapper mapper, string name, Action<TypedObjectMapper<T, TObject>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TObject : class
    {
        ArgumentNullException.ThrowIfNull(configure);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return mapper.AddTypedObject(new NamedObjectElement<T>(name), configure);
    }

    public static TMapper AddTypedObject<T, TMapper, TObject>(this TMapper mapper, Expression<Func<T, string>> nameExpression, Action<TypedObjectMapper<T, TObject>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TObject : class
    {
        ArgumentNullException.ThrowIfNull(configure);
        ArgumentNullException.ThrowIfNull(nameExpression);

        return mapper.AddTypedObject(new NamedObjectElement<T>(nameExpression), configure);
    }

    private static TMapper AddObject<T, TMapper>(this TMapper mapper, NamedObjectElement<T> namedObjectElement, Action<ObjectMapper<T>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        var objectMapper = new ObjectMapper<T>(namedObjectElement);
        configure(objectMapper);
        mapper.Container.Add(namedObjectElement);
        return mapper;
    }

    private static TMapper AddTypedObject<T, TMapper, TObject>(this TMapper mapper, NamedObjectElement<T> namedObjectElement, Action<TypedObjectMapper<T, TObject>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TObject : class
    {
        var objectMapper = new TypedObjectMapper<T, TObject>(namedObjectElement);
        configure(objectMapper);
        mapper.Container.Add(namedObjectElement);
        return mapper;
    }
}
