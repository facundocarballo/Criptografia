using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Algorithms
{
    public class Context
    {
        public UInt32[] X { get; set; }
        public UInt32[] C { get; set; }
        public UInt32 Carry { get; set; }

        public Context()
        {
            this.X = new UInt32[8];
            this.C = new UInt32[8];
            this.Carry = 0;
        }

        internal void CopyTo(Context other)
        {
            for (int i = 0; i < 8; i++)
            {
                other.X[i] = this.X[i];
                other.C[i] = this.C[i];
            }
            other.Carry = this.Carry;
        }
    }
}
