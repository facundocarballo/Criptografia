using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Algorithms
{
    public static class Bitwise
    {
        public static uint OR(params uint[] data)
        {
            if (data.Length < 2)
                throw new ArgumentException("Debe haber almenos dos elementos");
            var result = data[0];
            for (int i = 1; i < data.Length; i++)
                result |= data[i];
            return result;
        }
        public static uint SHIFT_LEFT(uint v1, int n)
        {
            return v1 << n;
        }

        public static uint SHIFT_RIGHT(uint v1, int n)
        {
            return v1 >> n;
        }

        public static uint ROTATE_LEFT(uint v1, int n)
        {
            return OR(SHIFT_LEFT(v1, n),SHIFT_RIGHT(v1,(32 - n)));
        }

    }
}
