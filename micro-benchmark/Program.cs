using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Diagnosers;

namespace MicroBenchmark
{
    [DisassemblyDiagnoser(printInstructionAddresses: true, syntax: DisassemblySyntax.Masm)]
    [MemoryDiagnoser]
    [RyuJitX64Job]
    public class DelegateSingleVsMulti
    {
        static int someCounter;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SomeCall() { someCounter++; }

        [Benchmark(Baseline=true)]
        public void BaseLine()
        {
            SomeCall();
            SomeCall();
            SomeCall();
        }

        [Benchmark]
        public void InlineFuncSingle()
        {
            var f = () => SomeCall();
            f();
            f();
            f();
        }

        [Benchmark]
        public void InlineFuncMultiple()
        {
            var fff = () => SomeCall();
            fff += () => SomeCall();
            fff += () => SomeCall();
            fff();
        }

        [Benchmark]
        public void DirectSingle()
        {
            var f = SomeCall;
            f();
            f();
            f();
        }

        [Benchmark]
        public void DirectMultiple()
        {
            var fff = SomeCall;
            fff += SomeCall;
            fff += SomeCall;
            fff();
        }
    }

    public class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
