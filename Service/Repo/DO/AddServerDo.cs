using ServerManager.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Repo.DO
{
    public class AddServerDo
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public PlatformType PlatformType { get; set; }
        public LoginInfo LoginInfo { get; set; }
        //public AddServerDo(string name, string host, int port, PlatformType platformType, LoginInfo loginInfo)
        //{
        //    Name = name;
        //    Host = host;
        //    Port = port;
        //    PlatformType = platformType;
        //    LoginInfo = loginInfo;
        //}
    }
}
