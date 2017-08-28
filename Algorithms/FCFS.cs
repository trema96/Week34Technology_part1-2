using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class FCFS : PAlgorithm
    {
        private Queue<IProcess> processes = new Queue<IProcess>();
        public override void AddProcesses(List<IProcess> processes)
        {
            foreach (IProcess process in processes)
            {
                this.processes.Enqueue(process);
            }
        }

        protected override void DoAlgorithm()
        {
            while (!IsQueueEmpty())
            {
                IProcess currProcess = processes.Dequeue();
                Console.WriteLine("Starting " + currProcess);
                while (!currProcess.ProcessOne()) ;
                Console.WriteLine("Stopping " + currProcess);
            }
        }

        protected override bool IsQueueEmpty()
        {
            return processes.Count <= 0;
        }
    }
}
