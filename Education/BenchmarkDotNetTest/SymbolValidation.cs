using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetTest
{

    public class SymbolValidation
    {
        private readonly string _symbol;

        public SymbolValidation()
        {
            _symbol = "AAPL.CV";
        }

        [Benchmark]
        public bool IsSymbolValidContainsString()
        {
            return !(_symbol.Contains("(") || _symbol.Contains(")"));
        }

        [Benchmark]
        public bool IsSymbolValidContainsChar()
        {
            return !(_symbol.Contains('(') || _symbol.Contains(')'));
        }

        public void RunBenchmarks()
        {
            var summary = BenchmarkRunner.Run<SymbolValidation>();
        }
    }
}
