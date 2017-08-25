using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Round Robin
    public class RR
    {
        private List<IProcess> processes;

        public RR(List<IProcess> processes)
        {
            this.processes = processes;
        }

        public void Execute()
        {
            // TODO: Implement the algorithm
            List<IProcess> toBeExecutedNext = new List<IProcess>(processes);
            while (toBeExecutedNext.Count > 0)
            {
                List<IProcess> currentExecution = new List<IProcess>(toBeExecutedNext);
                toBeExecutedNext.Clear();
                foreach (IProcess process in currentExecution)
                {
                    if (!process.RR_Process())
                    {
                        toBeExecutedNext.Add(process);
                    }
                }
            }
        }
    }
}
