
using Benchmark;
using BenchmarkDotNet.Running;

// run with
// dotnet run -c Release --framework net8.0 --runtimes net481 net6.0 net8.0

var summary = BenchmarkRunner.Run<EndianBenchmark>();
