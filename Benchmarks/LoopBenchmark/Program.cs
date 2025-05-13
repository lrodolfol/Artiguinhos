using BenchmarkDotNet.Running;
using PerformanceBenchmark;

internal class Program
{
    private static void Main(string[] args)
    {
        //var summary = BenchmarkRunner.Run<ComparacaoStringBenchmarks>();
        var summary = BenchmarkRunner.Run<CompareQuickSort>();
    }
}