using System.Diagnostics;

namespace NumericArrays.Profile;

class NumericArraysBenchmark {
    static void Main(string[] args) {
        var tmpArray = NA.Construct<int>([2, 3, 4]);
        var sw = Stopwatch.StartNew();
        
        sw.Stop();
        Console.WriteLine($"Elapsed time: {sw.ElapsedTicks} ms");
        Console.ReadLine();
    }
}
