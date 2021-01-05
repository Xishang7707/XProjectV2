using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Domain.VO
{
    public class LoginMethod : ValueObject
    {
        public int Method { get; private set; }
        private static readonly Dictionary<int, string> SupportMethodMap = new Dictionary<int, string>
        {
            {1, "Password" },
            {2, "PublicKey" },
        };

        public static bool IsSupportMethod(int method) => SupportMethodMap.ContainsKey(method);

        public LoginMethod(int method)
        {
            if (!IsSupportMethod(method))
                throw new Exception("不支持的登陆方式");

            Method = method;
        }
    }
}
