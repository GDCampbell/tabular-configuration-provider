using AzureTable.Provider.Configuration.Elements;

namespace AzureTable.Provider.Configuration.Mappers;

public abstract class BaseConfigurationMapper<TEntity> where TEntity : class
{
    private readonly ContainerElement<TEntity> _containerElement;
    internal ContainerElement<TEntity> Container => _containerElement;
    private protected BaseConfigurationMapper(ContainerElement<TEntity> containerElement)
        => _containerElement = containerElement;
}


public sealed class ConfigurationMapper<TEntity> : BaseConfigurationMapper<TEntity> where TEntity : class
{
    internal RootElement<TEntity> Element { get; }

    private ConfigurationMapper(RootElement<TEntity> element)
        : base(element)
        => Element = element;

    internal ConfigurationMapper() : this(new())
    {
    }
}


