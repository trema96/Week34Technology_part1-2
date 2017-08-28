using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SJN : PAlgorithm
    {
        private List<IProcess> processes = new List<IProcess>();
        public override void AddProcesses(List<IProcess> processes)
        {
            this.processes.AddRange(processes);
        }

        protected override void DoAlgorithm()
        {
            while (!IsQueueEmpty())
            {
                IProcess currProcess = GetNext();
                processes.Remove(currProcess);
                Console.WriteLine("Starting " + currProcess);
                while (!currProcess.ProcessOne()) ;
                Console.WriteLine("Stopping " + currProcess);
            }
        }

        protected override bool IsQueueEmpty()
        {
            return this.processes.Count <= 0;
        }

        private IProcess GetNext()
        {
            IProcess min = null;
            foreach (IProcess p in processes)
            {
                if (min == null || p.GetRunningTime() < min.GetRunningTime())
                {
                    min = p;
                }
            }
            return min;
        }
    }
}
