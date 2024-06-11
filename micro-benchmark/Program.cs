using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Diagnosers;

namespace MyBenchmarks
{
    [DisassemblyDiagnoser(printInstructionAddresses: true, syntax: DisassemblySyntax.Masm)]
    [RyuJitX64Job]
    public class DelegateSingleVsMulti
    {
        static int someCounter;

        public static void SomeCall() { someCounter++; }


        // | Method   | Mean       | Error     | StdDev    | Ratio  | RatioSD | Code Size |
        // |--------- |-----------:|----------:|----------:|-------:|--------:|----------:|
        // | Single   |  0.5485 ns | 0.0039 ns | 0.0036 ns |   1.00 |    0.00 |     227 B |
        // | Multiple | 99.6517 ns | 0.6371 ns | 0.5648 ns | 181.70 |    1.78 |   1,522 B |
        //
        [Benchmark(Baseline=true)]
        public void Single()
        {
            var f = () => SomeCall();
            f();
            f();
            f();
        }

        [Benchmark]
        public void Multiple()
        {
            var fff = () => SomeCall();
            fff += () => SomeCall();
            fff += () => SomeCall();
            fff();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
