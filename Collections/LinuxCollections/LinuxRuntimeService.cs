using Collections.LinuxCollections.Repo.Repository;
using Core.LongService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Collections.LinuxCollections
{
    public class LinuxRuntimeService : LongServiceAbstract, IDisposable
    {
        private Timer CollectionTimer { get; }
        private ServerRuntimeRepostory ServerRuntimeRepostory { get; }
        public LinuxRuntimeService(ServerRuntimeRepostory serverRuntimeRepostory)
        {
            ServerRuntimeRepostory = serverRuntimeRepostory;
            CollectionTimer = new Timer(LoopTask, null, 0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
        }

        public override Task Stop()
        {
            CollectionTimer.Dispose();
            return base.Stop();
        }

        private void LoopTask(object o)
        {
            var psi = new ProcessStartInfo("top", " -b -n 1") { RedirectStandardOutput = true };
            var proc = Process.Start(psi);
            List<string> outputBuffer = new List<string>();

            using var sr = proc.StandardOutput;
            while (!sr.EndOfStream)
            {
                var str = sr.ReadLine();
                outputBuffer.Add(str);
            }
            if (!proc.HasExited) proc.Kill();

            /*
             top - 12:58:50 up 32 min,  1 user,  load average: 0.01, 0.04, 0.05
             Tasks: 123 total,   1 running, 122 sleeping,   0 stopped,   0 zombie
             %Cpu(s): 20.0 us,  3.3 sy,  0.0 ni, 76.7 id,  0.0 wa,  0.0 hi,  0.0 si,  0.0 st
             KiB Mem :  1014608 total,   242968 free,   467440 used,   304200 buff/cache
             KiB Swap:  2097148 total,  2097148 free,        0 used.   385148 avail Mem 
             */
            string[] cpus = outputBuffer[2].Split(":")[1].Split(",").Select(s => s.Trim()).ToArray();
            ServerRuntimeRepostory.Add(new Core.Models.PO.PO_ServerRuntime
            {
                Id = Guid.NewGuid().ToString("N"),
                CpusUs = decimal.Parse(cpus[0].Split(" ")[0]),
                CpusSy = decimal.Parse(cpus[1].Split(" ")[0]),
                CpusNi = decimal.Parse(cpus[2].Split(" ")[0]),
                CpusId = decimal.Parse(cpus[3].Split(" ")[0]),
                Name = System.Net.Dns.GetHostName(),
                AddTime = DateTime.Now
            });
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
