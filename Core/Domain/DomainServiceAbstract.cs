using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public abstract class DomainServiceAbstract
    {
        protected void Assert(bool b, string s) { if (!b) throw new Exception(s); }
    }
}
