using AzureTable.Provider.Configuration.Elements;
using AzureTable.Provider.Configuration.Mappers;
using System.Linq.Expressions;

namespace AzureTable.Provider.Configuration.Extensions;

public static class ConfigurationMapperValueExtensions
{
    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, TValue>> valueExpression)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, string key, Func<T, TValue> valueFactory)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(valueFactory);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueFactory, key));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, string key, TValue value)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        return mapper.WithValue(ValueElement<T>.CreateFrom(key, value));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, TValue?>> valueExpression)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, string key, Func<T, TValue?> valueFactory)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(valueFactory);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueFactory, key));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, string key, TValue? value)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        return mapper.WithValue(ValueElement<T>.CreateFrom(key, value));
    }

    public static TMapper WithValue<T, TMapper>(this TMapper mapper, Expression<Func<T, string?>> valueExpression)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression));
    }

    public static TMapper WithValue<T, TMapper>(this TMapper mapper, string key, Func<T, string?> valueFactory)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        ArgumentNullException.ThrowIfNull(valueFactory);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueFactory, key));
    }

    public static TMapper WithValue<T, TMapper>(this TMapper mapper, string key, string? value)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);
        return mapper.WithValue(ValueElement<T>.CreateFrom(key, value));
    }

    private static TMapper WithValue<T, TMapper>(this TMapper mapper, ValueElement<T> element)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        mapper.Container.Add(element);
        return mapper;
    }
}