using Snippets.Constants;

var delimiter = new string('-', Console.WindowWidth);
Console.WriteLine("Snippets");
Console.WriteLine(delimiter);
Console.WriteLine();

Console.WriteLine("Application Constants converted to list of names");
Console.WriteLine(delimiter);
foreach (var name in ConstantToDictionary.All)
{
    Console.WriteLine(name);
}
Console.WriteLine(delimiter);
Console.WriteLine();


Console.WriteLine("Embedded Types converting constants to instances of the type.");
Console.WriteLine(delimiter);
Console.WriteLine($"Count: {ConstantToTypeCollection.All.Count}");
Console.WriteLine("Instances:");
foreach (var embeddedType in ConstantToTypeCollection.All)
{
    Console.WriteLine($"\t{embeddedType.ToDisplayString()}");
}
Console.WriteLine(delimiter);
Console.WriteLine();
Console.WriteLine("Finished");
Console.ReadKey();