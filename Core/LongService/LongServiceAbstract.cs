using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.LongService
{
    public abstract class LongServiceAbstract : ILongService
    {
        private ManualResetEvent LoopManual { get; }
        public LongServiceAbstract()
        {
            LoopManual = new ManualResetEvent(false);
        }
        public virtual Task Start()
        {
            LoopManual.WaitOne();
            return Task.CompletedTask;
        }

        public virtual Task Stop()
        {
            LoopManual.Set();
            return Task.CompletedTask;
        }
    }
}
