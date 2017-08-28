using Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OSScheduling
{
    class MyProcess : IProcess
    {
        private const int QUANTUM = 3;
        private readonly int _arrival;
        private readonly string _name;
        private readonly int _priority;
        private int _runningTime;
        private int timesRun = 0;

        public MyProcess(string name, int runningTime, int priority, int arrival)
        {
            _runningTime = runningTime;
            _priority = priority;
            _name = name;
            _arrival = arrival;
        }

        public bool ProcessOne()
        {
            Thread.Sleep(50);
            _runningTime--;
            Program.MyTimer.Increase();
            if (_runningTime > 0)
            {
                return false;
            }
            return true;
        }

        public bool Process()
        {
            Console.WriteLine("Starting {0}", ShowInfo());
            while (_runningTime > 0)
            {
                Thread.Sleep(50);
                //Program.MyTimer.ServiceTime++;
                _runningTime--;
            }
            Console.WriteLine("Stopping {0}\tWaittime: {1}", ShowInfo(), GetWaitTime());
            return true;
        }

        // RR Process
        public bool RR_Process()
        {
            // TODO: Implement method for Round-Robin
            if (timesRun == 0)
            {
                Console.WriteLine("Starting {0}", ShowInfo());
            }
            else
            {
                Console.WriteLine("Resuming {0}", ShowInfo());
            }
            int quantumTime = QUANTUM;
            while (_runningTime > 0 && quantumTime > 0)
            {
                Thread.Sleep(50);
                //Program.MyTimer.ServiceTime++;
                _runningTime--;
                quantumTime--;
            }
            timesRun++;
            if (_runningTime <= 0)
            {
                Console.WriteLine("Stopping {0}\tWaittime: {1}", ShowInfo(), GetWaitTime());
                return true;
            }
            else
            {
                Console.WriteLine("Pausing {0}\tWaittime: {1}", ShowInfo(), GetWaitTime());
                return false;
            }
        }

        public int GetRunningTime()
        {
            return _runningTime;
        }

        public int GetPriority()
        {
            return _priority;
        }

        public int GetArrivalTime()
        {
            return _arrival;
        }

        private int GetWaitTime()
        {
            return Program.MyTimer.ServiceTime - _arrival;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\tPriority: {1}\tRunningTime: {2}\tArrivalTime: {3}", _name, _priority,
                _runningTime, _arrival);
        }
        private string ShowInfo()
        {
            return string.Format("\tName: {0}\tPriority: {1}\tRunningTime: {2}\tArrivalTime: {3}", _name, _priority,
                _runningTime, _arrival);
        }
    }
}
