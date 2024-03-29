using System.Reflection;

namespace Snippets.Constants;

public static class ConstantToTypeCollection
{

    public static readonly List<EmbeddedType> All;

    public const string NAME = "My Name";
    public const string VERSION = "1.0.0";
    public const string DESCRIPTION = "My Description";

    static ConstantToTypeCollection()
    {

        // Step by step explanation
        var type = typeof(ConstantToDictionary);
        var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        var constantFields = fieldInfos.Where(fi => fi is { IsLiteral: true, IsInitOnly: false });
        var embeddedTypes = constantFields.Select(fi => new EmbeddedType
        {
            Name = fi.Name,
            Value = fi.GetValue(null)?.ToString() ?? string.Empty,
        });
        All = embeddedTypes.ToList();

    }

}

public class EmbeddedType
{
    public Guid InstanceId { get; } = Guid.NewGuid();
    public DateTime Timestamp { get; } = DateTime.Now;
    public string Name { get; init; } = default!;
    public string Value { get; init; } = default!;
}

public static class EmbeddedTypeExtension
{

    public static string ToDisplayString(this EmbeddedType embeddedType)
    {
        return $"{nameof(embeddedType.InstanceId)}:{embeddedType.InstanceId}; " +
               $"{nameof(embeddedType.Timestamp)}:{embeddedType.Timestamp:G}; " +
               $"{nameof(embeddedType.Name)}:{embeddedType.Name}; " +
               $"{nameof(embeddedType.Value)}{embeddedType.Value};";
    }

}