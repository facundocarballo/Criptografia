using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Algorithms
{
    internal static class Extensions
    {
        internal static UInt32 IsLessThan(this UInt32 value, UInt32 compare)
        {
            return (UInt32)(value < compare ? 1 : 0);
        }
    }
}
