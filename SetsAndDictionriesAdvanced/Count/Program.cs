
using System.Diagnostics.SymbolStore;
string text = Console.ReadLine();
SortedDictionary<char,int> symbols = new(); 
for (int i = 0; i < text.Length; i++)
{
	if (!symbols.ContainsKey(text[i]))
	{
		symbols[text[i]] = 0;
	}
	symbols[text[i]]++;
}
foreach (var item in symbols)
{
    Console.WriteLine($"{item.Key}: {item.Value} time/s");
}
