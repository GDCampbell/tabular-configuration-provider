using AzureTable.Provider.Configuration.Mapping.Elements;
using System.Linq.Expressions;

namespace AzureTable.Provider.Configuration.Mapping;

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

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, TValue>> valueExpression, string keyOverride)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(keyOverride);
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression, keyOverride));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, TValue?>> valueExpression, string keyOverride)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(keyOverride);
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression, keyOverride));
    }

    public static TMapper WithValue<T, TMapper, TValue>(this TMapper mapper, Expression<Func<T, TValue?>> valueExpression)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
        where TValue : struct, IFormattable
    {
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression));
    }

    public static TMapper WithValue<T, TMapper>(this TMapper mapper, Expression<Func<T, string?>> valueExpression, string keyOverride)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(keyOverride);
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression, keyOverride));
    }

    public static TMapper WithValue<T, TMapper>(this TMapper mapper, Expression<Func<T, string?>> valueExpression)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        ArgumentNullException.ThrowIfNull(valueExpression);
        return mapper.WithValue(ValueElement<T>.CreateFrom(valueExpression));
    }

    private static TMapper WithValue<T, TMapper>(this TMapper mapper, ValueElement<T> element)
        where T : class
        where TMapper : BaseConfigurationMapper<T>
    {
        mapper.Container.Add(element);
        return mapper;
    }
}