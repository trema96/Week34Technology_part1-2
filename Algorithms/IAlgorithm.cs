using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IAlgorithm
    {
        void SetCompleted();
        void Execute(Action queueEmpty);
        void AddProcesses(List<IProcess> processes);
    }
}
