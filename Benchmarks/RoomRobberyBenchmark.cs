using System.Linq;
using AutoFixture;
using BenchmarkDotNet.Attributes;
using Questions.Interview;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class RoomRobberyBenchmark
    {
        private static IFixture Fixture = new Fixture();
        private static readonly RoomRobbery RoomRobbery = new();
        public static readonly int[] Input = Fixture.CreateMany<int>(10000).ToArray();

        [Benchmark]
        public int RobMykhailo() => RoomRobbery.Rob(Input);

        [Benchmark]
        public int RobEugene() => RoomRobbery.RobEugene(Input);
    }
}