using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using CheckDuplicates;

Console.WriteLine($"Check Duplicates:{Environment.NewLine}");

ManualConfig config = new ManualConfig().WithOptions(ConfigOptions.DisableOptimizationsValidator)
                                        .AddValidator(JitOptimizationsValidator.DontFailOnError)
                                        .AddLogger(ConsoleLogger.Default)
                                        .AddColumnProvider(DefaultColumnProviders.Instance);

BenchmarkRunner.Run<Benchmark>(config);
Console.ReadKey();



//var elements = Benchmark.RandomArray(1, 100);
//Benchmark benchmark = new Benchmark(elements);

//Console.WriteLine($"Foreach: {benchmark.Foreach()}");
//Console.WriteLine($"LinqAny: {benchmark.LinqAny()}");
//Console.WriteLine($"LinqAll: {benchmark.LinqAll()}");
//Console.WriteLine($"LinqDistinctCount: {benchmark.LinqDistinctCount()}");
//Console.WriteLine($"ToHashSet: {benchmark.ToHashSet()}");
//Console.WriteLine($"LinqGroupBy: {benchmark.LinqGroupBy()}");
//Console.WriteLine($"LinqWhereDistinct: {benchmark.LinqWhereDistinct()}");