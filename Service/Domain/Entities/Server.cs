using Core.Models;
using ServerManager.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServerManager.Domain.Entities
{
    public class Server : Entity
    {
        public string Name { get; private set; }
        public string Host { get; private set; }
        public int Port { get; private set; }
        public PlatformType PlatformType { get; set; }
        public LoginInfo LoginInfo { get; set; }
        public Server(Guid id, string name, string host, int port, PlatformType platformType, LoginInfo loginInfo) : base(id)
        {
            Valid(name, host, port, platformType, loginInfo);

            Name = name;
            Host = host;
            Port = port;
            PlatformType = platformType;
            LoginInfo = loginInfo;
        }

        private static void Valid(string name, string host, int port, PlatformType platformType, LoginInfo loginInfo)
        {
            ValidName(name);
            ValidHost(host);
            ValidPort(port);

            if (platformType == null) throw new Exception("平台类型无效");
            if (loginInfo == null) throw new Exception("登陆信息无效");
        }

        public static void ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("服务器名称无效");
            if (name.Length > 128) throw new Exception("服务器名称最多128个字符");
        }

        public static void ValidHost(string host)
        {
            if (string.IsNullOrWhiteSpace(host)) throw new Exception("主机无效");
            if (!Regex.IsMatch(host, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$")
                || !Regex.IsMatch(host, @"^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\-]*[a-zA-Z0-9])\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\-]*[A-Za-z0-9])$")) throw new Exception("无效的主机地址");
        }

        public static void ValidPort(int port)
        {
            if (port <= 0 || port > 65535) throw new Exception("端口无效");
        }
    }
}
