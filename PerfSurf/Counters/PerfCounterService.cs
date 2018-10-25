using System.Collections.Generic;
using System.Linq;

namespace PerfSurf.Counters
{
    public class PerfCounterService
    {
        public PerfCounterService()
        {
            _counters = new List<PerfCounterWrapper>();

            _counters.Add(new PerfCounterWrapper("Process", "Processor", "% Processor Time", "_Total"));
            _counters.Add(new PerfCounterWrapper("Paging", "Memory", "Pages/sec"));
            _counters.Add(new PerfCounterWrapper("Disk", "PhysicalDisk", "% Disk Time", "_Total"));
        }

        public dynamic GetResults() => _counters.Select(c => new { name = c.Name, value = c.Value });

        List<PerfCounterWrapper> _counters { get; set; }
    }
}