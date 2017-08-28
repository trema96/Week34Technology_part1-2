using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IProcess
    {
        bool ProcessOne();
        bool Process();
        bool RR_Process();
        int GetRunningTime();
        int GetPriority();
        int GetArrivalTime();
    }
}
