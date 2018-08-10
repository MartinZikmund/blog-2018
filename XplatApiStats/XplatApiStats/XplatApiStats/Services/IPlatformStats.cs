using System;
using System.Collections.Generic;
using System.Text;

namespace XplatApiStats.Services
{
    public interface IPlatformStats
    {
        ApiStats GetStats();
    }
}
