using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.PO
{
    public class PO_Server
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public int PlatformType { get; set; }
        public string LoginUser { get; set; }
        public int LoginMethod { get; set; }
        public string Password { get; set; }
        public string PublicKey { get; set; }
        public string PublicKeyPassword { get; set; }
        public DateTime AddTime { get; set; }
    }
}
