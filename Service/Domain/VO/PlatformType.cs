using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Domain.VO
{
    public class PlatformType : ValueObject
    {
        public int Type { get; private set; }
        private static readonly Dictionary<int, string> SupportTypeMap = new Dictionary<int, string>
        {
            {1, "Linux" },
        };

        public static bool IsSupportMethod(int type) => SupportTypeMap.ContainsKey(type);

        public PlatformType(int type)
        {
            if (!IsSupportMethod(type))
                throw new Exception("不支持的平台类型");

            Type = type;
        }
    }
}
