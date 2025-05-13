using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmark
{
    public class CompareQuickSort
    {
        private List<int> Lisnum = new List<int>();
        public CompareQuickSort()
        {
            var rand = new Random();
            var num = 0;

            for (int i = 0; i < 10_000; i++)
            {
                num = rand.Next(1, 10_000);
                Lisnum.Add(num);
            }
        }

        [Benchmark]
        public void WitchOrderDotNet()
        {
            var order = Lisnum.Order();
        }

        [Benchmark]
        public void DivideAndConquer()
        {
            var order = Order(Lisnum);

            List<int> Order(List<int> source)
            {
                if (source.Count < 2)
                    return source;

                int pivot = source[0];
                var left = new List<int>();
                var right = new List<int>();

                var grather = source.Skip(1).Where(x => x > pivot).ToList();
                var less = source.Skip(1).Where(x => x <= pivot).ToList();


                return Order(less).Concat(new List<int> { pivot }).Concat(Order(grather)).ToList();
            }
        }

    }
}