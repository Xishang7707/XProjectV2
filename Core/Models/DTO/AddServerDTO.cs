using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.DTO
{
    public class AddServerDTO
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string PlatformType { get; set; }
        public string LoginUser { get; set; }
        public string LoginMethod { get; set; }
        public string Password { get; set; }
        public string PublicKey { get; set; }
        public string PublicKeyPassword { get; set; }
    }
}
