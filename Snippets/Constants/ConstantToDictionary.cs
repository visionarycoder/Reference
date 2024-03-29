using System.Reflection;

namespace Snippets.Constants;

public class ConstantToDictionary
{

    public const string APPLICATION_NAME = "MyApp";
    public const string APPLICATION_VERSION = "1.0.0";
    public const string APPLICATION_DESCRIPTION = "MyApp is a sample application";

    public static readonly Dictionary<string, string> All;

    static ConstantToDictionary()
    {

        // Step by step explanation
        var type = typeof(ConstantToDictionary);
        var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        var constantFields = fieldInfos.Where(fi => fi is { IsLiteral: true, IsInitOnly: false });
        var data = constantFields.Select(fi => new KeyValuePair<string,string>(fi.Name, fi.GetValue(null)?.ToString() ?? string.Empty));
        All = data.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

    }

}