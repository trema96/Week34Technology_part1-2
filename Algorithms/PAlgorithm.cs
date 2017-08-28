using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public abstract class PAlgorithm : IAlgorithm
    {
        private bool completed = false;

        public abstract void AddProcesses(List<IProcess> processes);

        protected abstract bool IsQueueEmpty();

        protected abstract void DoAlgorithm();

        public void Execute(Action queueEmpty)
        {
            while (!completed)
            {
                if (IsQueueEmpty())
                {
                    queueEmpty.Invoke();
                }
                else
                {
                    DoAlgorithm();
                }
            }
        }

        public void SetCompleted()
        {
            completed = true;
        }
    }
}
