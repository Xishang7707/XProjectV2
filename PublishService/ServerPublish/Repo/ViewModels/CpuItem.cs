using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishService.ServerPublish.Repo.ViewModels
{
    public class CpuItem
    {
        public string Id { get; set; }
        public int CpuUtilization { get; set; }
        public DateTime Time { get; set; }
    }
}
