using System.Diagnostics;
using System.Text;

namespace ds.Utility
{
    public class Instrumentation
    {
        public static string GetMetrics(string label, Action action)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            long beforeMemory = GC.GetTotalMemory(true);
            Stopwatch stopwatch = Stopwatch.StartNew();
            action.Invoke();
            long afterMemory = GC.GetTotalMemory(true);
            stopwatch.Stop();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return $"{label} time: {stopwatch.ElapsedMilliseconds.ToString()} milliseconds|{label} memory consumption: {(afterMemory - beforeMemory):F0} bytes";
        }

        ~Instrumentation() { GC.Collect(); }
    }
}
