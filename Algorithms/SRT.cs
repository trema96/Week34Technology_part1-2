using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SRT : PAlgorithm
    {
        private List<IProcess> processes = new List<IProcess>();
        private IProcess current;
        public override void AddProcesses(List<IProcess> ps)
        {
            this.processes.AddRange(ps);
            IProcess min = Utils.MinBy(ps, Comparer<IProcess>.Create((x, y) => x.GetRunningTime() - y.GetRunningTime()));
            if (current != null && current.GetRunningTime() > min.GetRunningTime())
            {
                current = min;
            }
        }

        protected override void DoAlgorithm()
        {
            bool changed = true;
            while (!IsQueueEmpty())
            {
                if (current == null)
                {
                    current = Utils.MinBy(processes, Comparer<IProcess>.Create((x, y) => x.GetRunningTime() - y.GetRunningTime()));
                }
                IProcess executing = current;
                if (changed)
                {
                    Console.WriteLine("Starting " + executing);
                    changed = false;
                }
                if (executing.ProcessOne())
                {
                    this.processes.Remove(executing);
                    current = null;
                    changed = true;
                }
                if (current == null)
                {
                    Console.WriteLine("Stopping " + executing);
                }
                else if (current != executing)
                {
                    Console.WriteLine("Pausing " + executing);
                    changed = true;
                }
            }
        }

        protected override bool IsQueueEmpty()
        {
            return processes.Count == 0;
        }
    }
}
