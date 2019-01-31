using System.Diagnostics;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Random.Api.Tests.Unit
{
    public class RandomGeneratorTests
    {
        private readonly ITestOutputHelper _output;

        public RandomGeneratorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Run_Thousand_Times_And_Get_Average_Performance()
        {
            var rnd = new RandomGenerator();
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                rnd.RandomIntArray(1000);
            }


            sw.Stop();

            _output.WriteLine("Elapsed={0}", sw.Elapsed / 1000);
        }

        [Fact]
        public void Check_That_No_Number_Is_Omitted_Or_Repeated()
        {
            var rnd = new RandomGenerator();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            var data = rnd.RandomIntArray(1000);
            sw.Stop();

            _output.WriteLine("Elapsed={0}", sw.Elapsed);
            var sorted = data.OrderBy(i => i).ToArray();

            for (int i = 0; i < 1000; i++)
            {
                Assert.Equal(i + 1, sorted[i]);
            }
        }
    }
}