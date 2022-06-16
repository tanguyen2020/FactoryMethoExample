public interface ITypeService
{
    bool Authenticate();
}

public interface IContentTypeService
{
    ITypeService GetService(string resourceService);
}


public class ContentTypeService : IContentTypeService
{
    private readonly IServiceProvider _serviceProvider;
    public ContentTypeService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public ITypeService GetService(string resourceService)
    {
        var source = string.Join("", resourceService.Split('-').Where(t => !t.IsNullOrEmpty())
              .Select(t => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t.ToLower())));

        var nameTypeService = $"{this.GetType().Namespace}.{resourceService}";
        Type typeService = Type.GetType(nameTypeService);
        if (typeService == null) throw new Exception();

        var constructors = typeService.GetConstructors();
        var constructorInfoParams = new List<object>();
        if (constructors != null)
        {
            var constructorInfo = constructors.First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                constructorInfoParams.Add(_serviceProvider.GetService(parameter.ParameterType));
            }
        }
        return typeService != null && typeService.GetInterface(nameof(ITypeService)) != null
        ? (ITypeService)Activator.CreateInstance(typeService, constructorInfoParams.ToArray())
        : null;
    }
}
