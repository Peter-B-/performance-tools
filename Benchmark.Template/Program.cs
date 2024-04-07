using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Buffers.Binary;

// run with
// dotnet run -c Release

var summary = BenchmarkRunner.Run<EndianBenchmark>();


public class EndianBenchmark
{
    private readonly byte[] data = new byte[8];

    public EndianBenchmark()
    {
        BinaryPrimitives.WriteInt64BigEndian(data, -1234567890123456789);
    }

    [Benchmark(Baseline = true)]
    public long Custom() =>
        ((long)data[0] << (7 * 8)) |
        ((long)data[1] << (6 * 8)) |
        ((long)data[2] << (5 * 8)) |
        ((long)data[3] << (4 * 8)) |
        ((long)data[4] << (3 * 8)) |
        ((long)data[5] << (2 * 8)) |
        ((long)data[6] << (1 * 8)) |
        ((long)data[7] << (0 * 8));

    [Benchmark]
    public long UsingBinaryPrimitives() =>
        BinaryPrimitives.ReadInt64BigEndian(data);
}