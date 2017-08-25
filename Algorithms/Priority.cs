using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Priority Scheduling
    public class Priority
    {
        private List<IProcess> processes;

        public Priority(List<IProcess> processes)
        {
            this.processes = processes;
        }

        public void Execute()
        {
            var sorted = processes.OrderByDescending(x => x.GetPriority());
            foreach (IProcess p in sorted)
            {
                p.Process();
            }
        }
    }
}
