namespace Bazar.Api.Helpers;

public static class PropertiesMapper
{
    public static void UpdateProperties<T>(T source, T target)
    {
        var type = typeof(T);
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            if (property is not { CanRead: true, CanWrite: true } || property.GetValue(source) is null) continue;
            var value = property.GetValue(source);
            property.SetValue(target, value);
        }
    }
}