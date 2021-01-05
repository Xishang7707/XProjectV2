using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.LongService
{
    public interface ILongService
    {
        public Task Start();
        public Task Stop();
    }
}
