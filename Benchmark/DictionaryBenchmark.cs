using System.Collections.ObjectModel;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[SimpleJob(RuntimeMoniker.Net481)]
[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
[SimpleJob(RuntimeMoniker.Net80)]
public class DictionaryBenchmark
{
    private Dictionary<string, Guid> dictionary;
    private ReadOnlyDictionary<string, Guid> readOnlyDictionary;
    private string[] guids;
    private readonly Random random = new();

    [Params(1000)]
    public int Items { get; set; }

    [Params("current", "ordinal", "ordinal IC", "current IC")]
    public string Comparer { get; set; }

    [Benchmark]
    public Guid Dictionary()
    {
        var idx = random.Next(0, Items);
        var guid = this.guids[idx];
        return dictionary[guid];
    }

    [Benchmark]
    public Guid ReadOnlyDictionary()
    {
        var idx = random.Next(0, Items);
        var guid = this.guids[idx];
        return dictionary[guid];
    }

    [GlobalSetup]
    public void GlobalSetup()
    {
        guids = new string[Items];
        dictionary = new Dictionary<string, Guid>(GetComparer());

        for (var i = 0; i < guids.Length; i++)
        {
            var guid = Guid.NewGuid();
            var key = guid.ToString();
            guids[i] = key;
            dictionary[key] = guid;
        }

        readOnlyDictionary = new ReadOnlyDictionary<string, Guid>(dictionary);
    }

    private StringComparer GetComparer() =>
        Comparer switch
        {
            "current" => StringComparer.CurrentCulture,
            "current IC" => StringComparer.CurrentCulture,
            "ordinal" => StringComparer.Ordinal,
            "ordinal IC" => StringComparer.OrdinalIgnoreCase,
        };
}