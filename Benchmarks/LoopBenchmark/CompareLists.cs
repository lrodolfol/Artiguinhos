using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmark
{
    public class ComparacaoStringBenchmarks
    {
        [Benchmark]
        public void Insert_10_000_WithArray()
        {
            int[] numeros = new int[10_000];
            for (int i = 0; i < 10_000; i++)
            {
                numeros[i] = i;
            }
        }

        [Benchmark]
        public void Insert_10_000_WithList()
        {
            List<int> numeros = new List<int>(10_000);
            for (int i = 0; i < 10_000; i++)
            {
                numeros.Add(i);
            }
        }

        [Benchmark]
        public void Insert_10_000_WithLinkedList()
        {
            LinkedList<int> numeros = new LinkedList<int>();
            for (int i = 0; i < 10_000; i++)
            {
                numeros.AddFirst(i);
            }
        }

        [Benchmark]
        public void Insert_10_000_WithDictionary()
        {
            Dictionary<int, int> numeros = new Dictionary<int, int>();
            for (int i = 0; i < 10_000; i++)
            {
                numeros.Add(i, i);
            }
        }
    }
}