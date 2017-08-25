using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Shortest-Job-Next
    public class SJN
    {
        private List<IProcess> processes;

        public SJN(List<IProcess> processes)
        {
            this.processes = processes;
        }

        public void Execute()
        {
            // TODO: Implement the algorithm
            var sorted = processes.OrderBy(x => x.GetRunningTime());
            foreach (IProcess process in sorted)
            {
                process.Process();
            }
        }
    }
}
