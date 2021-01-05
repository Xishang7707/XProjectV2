using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishService.ServerPublish.Repo.ViewModels
{
    public class ServerRuntimeInfo
    {
        public IEnumerable<CpuItem> Cpu { get; set; }
    }
}
