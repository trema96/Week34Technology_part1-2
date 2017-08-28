using System;
using System.Collections.Generic;
using System.Threading;
using Algorithms;

namespace OSScheduling
{
    internal class Program
    {
        public static class MyTimer
        {
            public static int ServiceTime { get; private set; } = 0;
            public static AlgorithmManager manager;
            public static bool Increase()
            {
                ServiceTime++;
                return manager.TimeIncreased();
            }
        }

        private static void Main(string[] args)
        {
            var processList = new List<IProcess>();
            var rnd = new Random();
            for (var i = 0; i < 100; i++)
            {
                processList.Add(new MyProcess("Process# " + i, rnd.Next(1, 10), rnd.Next(1, 1000), rnd.Next(1, 100)));
            }

            // TODO: Run algorithm
            //FCFS alg = new FCFS(processList);
            //SJN alg = new SJN(processList);
            //SRT alg = new SRT(processList);
            //Priority alg = new Priority(processList);
            //RR alg = new RR(processList);

            MyTimer.manager = new AlgorithmManager(processList, new SRT());
            MyTimer.manager.Start();
            Console.WriteLine("--- Press Enter to continue ---");
            Console.ReadLine();
        }
    }

    public class AlgorithmManager
    {
        private List<IProcess> processes;
        private IAlgorithm alg;

        public AlgorithmManager(List<IProcess> processes, IAlgorithm alg)
        {
            this.processes = processes;
            this.alg = alg;
        }

        public void Start()
        {
            TimeIncreased();
            alg.Execute(() => NotifyEmptyQueue());
        }
        public bool TimeIncreased()
        {
            //aggiungi eventuali processi; se ne hai aggiunti (o son finiti) ritorna true;
            if (processes.Count == 0)
            {
                alg.SetCompleted();
                return true;
            }
            var newProcesses = processes.FindAll(p => p.GetArrivalTime() == Program.MyTimer.ServiceTime);
            if (newProcesses.Count == 0)
            {
                return false;
            }
            processes.RemoveAll(p => p.GetArrivalTime() == Program.MyTimer.ServiceTime);
            alg.AddProcesses(newProcesses);
            return true;
        }
        public void NotifyEmptyQueue()
        {
            if (processes.Count > 0)
            {
                bool res;
                do
                {
                    res = Program.MyTimer.Increase();
                } while (!res);
            }
            else
            {
                alg.SetCompleted();
            }
        }
    }
}