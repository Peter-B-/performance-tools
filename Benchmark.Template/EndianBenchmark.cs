using System.Buffers.Binary;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[SimpleJob(RuntimeMoniker.Net481, baseline: true)]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net80)]
public class EndianBenchmark
{
    private readonly byte[] _data = new byte[8];

    public EndianBenchmark()
    {
        BinaryPrimitives.WriteInt64BigEndian(_data, 1234567890123456L);
    }

    [Benchmark(Baseline = true)]
    public long UsingBinaryPrimitives()
    {
        return BinaryPrimitives.ReadInt64BigEndian(_data);
    }

    [Benchmark]
    public long Custom()
    {
        return
            ((long)_data[0] << (7 * 8)) |
            ((long)_data[1] << (6 * 8)) |
            ((long)_data[2] << (5 * 8)) |
            ((long)_data[3] << (4 * 8)) |
            ((long)_data[4] << (3 * 8)) |
            ((long)_data[5] << (2 * 8)) |
            ((long)_data[6] << (1 * 8)) |
            ((long)_data[7] << (0 * 8));
    }
}