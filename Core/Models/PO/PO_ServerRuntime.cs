using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.PO
{
    public class PO_ServerRuntime
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal CpusUs { get; set; }
        public decimal CpusSy { get; set; }
        public decimal CpusNi { get; set; }
        public decimal CpusId { get; set; }
        public DateTime AddTime { get; set; }
    }
}
