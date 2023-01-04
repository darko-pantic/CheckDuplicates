using BenchmarkDotNet.Attributes;

namespace CheckDuplicates
{
    [MemoryDiagnoser(false)]
    public class Benchmark
    {
        #region Properties
        [Params(100, 1_000, 10_000)]
        public static int Size { get; set; }

        private int[] Elements { get; set; }
        #endregion

        #region Constructors
        public Benchmark()
        {
        }

        public Benchmark(int[] elements)
        {
            this.Elements = elements;
        }
        #endregion

        #region Publics
        public static int[] RandomArray(int min, int max) => Enumerable.Repeat(min, max)
                                                                       .Select(i => new Random().Next(min, max))
                                                                       .ToArray();

        [GlobalSetup]
        public void Setup()
        {
            this.Elements = Enumerable.Range(1, Size)
                                      .ToArray();

            int index = (int) (Size * 0.2);

            this.Elements[index] = this.Elements[index + 1];
        }

        [Benchmark]
        public bool Foreach()
        {
            return HasDuplicates.ForEach(this.Elements);
        }

        [Benchmark]
        public bool LinqAny()
        {
            return HasDuplicates.LinqAny(this.Elements);
        }

        [Benchmark]
        public bool LinqAll()
        {
            return HasDuplicates.LinqAll(this.Elements);
        }

        [Benchmark]
        public bool LinqDistinctCount()
        {
            return HasDuplicates.LinqDistinctCount(this.Elements);
        }

        [Benchmark]
        public bool ToHashSet()
        {
            return HasDuplicates.ToHashSet(this.Elements);
        }

        [Benchmark]
        public bool LinqGroupBy()
        {
            return HasDuplicates.LinqGroupBy(this.Elements);
        }

        [Benchmark]
        public bool LinqWhereDistinct()
        {
            return HasDuplicates.LinqWhereDistinct(this.Elements);
        }
        #endregion
    }
}