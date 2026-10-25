using AzureTable.Provider.Configuration.Elements;
using AzureTable.Provider.Configuration.Mappers;
using System.Linq.Expressions;

namespace AzureTable.Provider.Configuration.Extensions;

public static class ConfigurationMapperArrayExtensions
{
    public static TMapper AddPrimitiveArray<T, TMapper, TValue>(this TMapper mapper, string name, Action<SimpleArrayMapper<T, TValue>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(configure);

        var arrayMapper = new SimpleArrayMapper<T, TValue>(name);

        configure(arrayMapper);

        return mapper.AddPrimitiveArray(arrayMapper.Element);
    }

    public static TMapper AddPrimitiveArray<T, TMapper, TValue>(this TMapper mapper, string name, Action<SimpleArrayMapper<T, TValue?>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(configure);

        var arrayMapper = new SimpleArrayMapper<T, TValue?>(name);

        configure(arrayMapper);

        return mapper.AddPrimitiveArray(arrayMapper.Element);
    }

    public static TMapper AddPrimitiveArray<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, string>> nameExpression, Action<SimpleArrayMapper<T, TValue>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentNullException.ThrowIfNull(nameExpression);
        ArgumentNullException.ThrowIfNull(configure);

        var arrayMapper = new SimpleArrayMapper<T, TValue>(nameExpression);

        configure(arrayMapper);

        return mapper.AddPrimitiveArray(arrayMapper.Element);
    }

    public static TMapper AddPrimitiveArray<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, string>> nameExpression, Action<SimpleArrayMapper<T, TValue?>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentNullException.ThrowIfNull(nameExpression);
        ArgumentNullException.ThrowIfNull(configure);

        var arrayMapper = new SimpleArrayMapper<T, TValue?>(nameExpression);

        configure(arrayMapper);

        return mapper.AddPrimitiveArray(arrayMapper.Element);
    }

    public static TMapper AddStringArray<T, TMapper>(this TMapper mapper, Expression<Func<T, string>> nameExpression, Action<SimpleArrayMapper<T, string?>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentNullException.ThrowIfNull(nameExpression);
        ArgumentNullException.ThrowIfNull(configure);

        var arrayMapper = new SimpleArrayMapper<T, string?>(nameExpression);

        configure(arrayMapper);

        return mapper.AddPrimitiveArray(arrayMapper.Element);
    }

    public static TMapper AddStringArray<T, TMapper>(this TMapper mapper, string name, Action<SimpleArrayMapper<T, string?>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(configure);

        var arrayMapper = new SimpleArrayMapper<T, string?>(name);

        configure(arrayMapper);

        return mapper.AddPrimitiveArray(arrayMapper.Element);
    }

    public static TMapper AddComplexArray<T, TMapper>(this TMapper mapper, string name, Action<ComplexArrayMapper<T>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(configure);

        var objectMapper = new ComplexArrayMapper<T>(name);

        configure(objectMapper);

        return mapper.AddComplexArray(objectMapper.Element);
    }

    public static TMapper AddComplexArray<T, TMapper>(this TMapper mapper, Expression<Func<T, string>> nameExpression, Action<ComplexArrayMapper<T>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentNullException.ThrowIfNull(nameExpression);
        ArgumentNullException.ThrowIfNull(configure);

        var objectMapper = new ComplexArrayMapper<T>(nameExpression);

        configure(objectMapper);

        return mapper.AddComplexArray(objectMapper.Element);
    }

    public static TMapper AddTypedComplexArray<T, TMapper, TObject>(this TMapper mapper, string name, Action<TypedComplexArrayMapper<T, TObject>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TObject : class
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(configure);

        var typedArrayMapper = new TypedComplexArrayMapper<T, TObject>(name);

        configure(typedArrayMapper);

        return mapper.AddComplexArray(typedArrayMapper.Element);
    }

    public static TMapper AddTypedComplexArray<T, TMapper, TObject>(this TMapper mapper, Func<T, string> nameFactory, Action<TypedComplexArrayMapper<T, TObject>> configure)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TObject : class
    {
        ArgumentNullException.ThrowIfNull(nameFactory);
        ArgumentNullException.ThrowIfNull(configure);

        var typedArrayMapper = new TypedComplexArrayMapper<T, TObject>(nameFactory);

        configure(typedArrayMapper);

        return mapper.AddComplexArray(typedArrayMapper.Element);
    }

    private static TMapper AddPrimitiveArray<T, TMapper>(this TMapper mapper, SimpleArrayElement<T> element)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        mapper.Container.Add(element);
        return mapper;
    }

    private static TMapper AddComplexArray<T, TMapper>(this TMapper mapper, ComplexArrayElement<T> element)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        mapper.Container.Add(element);
        return mapper;
    }


}
