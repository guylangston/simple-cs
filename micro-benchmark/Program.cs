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

        public static void Reset() => someCounter = 0;

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
            // var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            var n = new DelegateSingleVsMulti();

            // warmup
            for (var cc=0; cc<10_000; cc++) n.DirectSingle();

            DelegateSingleVsMulti.Reset();
            n.DirectSingle();
        }
    }
}
