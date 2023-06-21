using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Algorithms
{
    public class RabbitAlgorithm : IRabbitAlgorithm
    {
        public readonly Context master;
        public readonly Context context;

        public RabbitAlgorithm(byte[] key)
        {
            this.master = new Context();
            this.context = new Context();

            this.KeySetup(key);
        }

        public byte[] Cipher(byte[] data)
        {
            var result = new List<byte>();
            for(int i = 0; i < data.Length; i+=16)
            {
                this.NextState(this.context);
                result.AddRange(BitConverter.GetBytes(BitConverter.ToUInt32(data, i + 0) ^ this.context.X[0] ^ (this.context.X[5] >> 16) ^ (this.context.X[3] << 16)));
                result.AddRange(BitConverter.GetBytes(BitConverter.ToUInt32(data, i + 4) ^ this.context.X[2] ^ (this.context.X[7] >> 16) ^ (this.context.X[5] << 16)));
                result.AddRange(BitConverter.GetBytes(BitConverter.ToUInt32(data, i + 8) ^ this.context.X[4] ^ (this.context.X[1] >> 16) ^ (this.context.X[7] << 16)));
                result.AddRange(BitConverter.GetBytes(BitConverter.ToUInt32(data, i + 12) ^ this.context.X[6] ^ (this.context.X[3] >> 16) ^ (this.context.X[1] << 16)));
                
            }
            return result.ToArray();
        }

        public void IVSetup(byte[] iv)
        {
            // Convertimos los 8 bytes del IV en enteros sin signo de 32 bits
            UInt32 i0 = BitConverter.ToUInt32(iv, 0);
            UInt32 i1 = BitConverter.ToUInt32(iv, 4);

            // Utilizamos estos enteros sin signo de 32 bits, para obtener otros dos mas.
            UInt32 i2 = (i0 >> 16) | (i1 & 0xFFFF0000);
            UInt32 i3 = (i1 << 16) | (i0 & 0x0000FFFF);

            // Operaciones XOR con los contadores actuales del contexto.
            this.context.C[0] = this.master.C[0] ^ i0;
            this.context.C[1] = this.master.C[1] ^ i2;
            this.context.C[2] = this.master.C[2] ^ i1;
            this.context.C[3] = this.master.C[3] ^ i3;
            this.context.C[4] = this.master.C[4] ^ i0;
            this.context.C[5] = this.master.C[5] ^ i2;
            this.context.C[6] = this.master.C[6] ^ i1;
            this.context.C[7] = this.master.C[7] ^ i3;

            // Mover instancia master a work
            for (int i = 0; i < 8; i++)
                this.context.X[i] = this.master.X[i];
            this.context.Carry = this.master.Carry;

            // Iterar el sistema 4 veces
            for (int i = 0; i < 4; i++)
                this.NextState(this.context);
        }

        private void KeySetup(byte[] key)
        {
            // Dividimos la key (16 bytes) en 4 enteros sin signo de 4 bytes (32 bits)
            UInt32 k0 = BitConverter.ToUInt32(key, 0);
            UInt32 k1 = BitConverter.ToUInt32(key, 4);
            UInt32 k2 = BitConverter.ToUInt32(key, 8);
            UInt32 k3 = BitConverter.ToUInt32(key, 12);

            // Iniciar variables
            this.master.X[0] = k0;
            this.master.X[2] = k1;
            this.master.X[4] = k2;
            this.master.X[6] = k3;
            this.master.X[1] = (k3 << 16) | (k2 >> 16);
            this.master.X[3] = (k0 << 16) | (k3 >> 16);
            this.master.X[5] = (k1 << 16) | (k0 >> 16);
            this.master.X[7] = (k2 << 16) | (k1 >> 16);

            // Iniciar contadores
            this.master.C[0] = Bitwise.ROTATE_LEFT(k2, 16);
            this.master.C[2] = Bitwise.ROTATE_LEFT(k3, 16);
            this.master.C[4] = Bitwise.ROTATE_LEFT(k0, 16);
            this.master.C[6] = Bitwise.ROTATE_LEFT(k1, 16);
            this.master.C[1] = (k0 & 0xFFFF0000) | (k1 & 0xFFFF); // Operacion AND de k0 con una mascara de bits (16 bits mas significativos en 1). Operacion AND de k1 con una mascara (16 bits menos significativos en 1).
            this.master.C[3] = (k1 & 0xFFFF0000) | (k2 & 0xFFFF);
            this.master.C[5] = (k2 & 0xFFFF0000) | (k3 & 0xFFFF);
            this.master.C[7] = (k3 & 0xFFFF0000) | (k0 & 0xFFFF);

            // Limpiar carry - por default está en 0
            this.master.Carry = 0;

            // Iterar el sistema 4 veces
            for (int i = 0; i < 4; i++)
                this.NextState(this.master);

            // Modificar contadores
            for (int i = 0; i < 8; i++)
                this.master.C[i] ^= master.X[(i + 4) & 0x7];

            // Copiar master context a work context
            this.master.CopyTo(this.context);
        }

        private void NextState(Context ctx)
        {
            var g = new UInt32[8];
            var c_old = new UInt32[8];

            // Copiamos el contexto anterior a la variable c_old
            for (int i = 0; i < 8; i++)
                c_old[i] = ctx.C[i];

            // Se crea el nuevo estado en base al estado anterior.
            // Se incrementan las posiciones de 32 bits, utilizando 3 Constantes hexadecimales junto con un cero o uno dependiendo el resultado de la comparacion (o carry en el primer elemento)
            ctx.C[0] += 0x4D34D34D + ctx.Carry;
            ctx.C[1] += 0xD34D34D3 + ctx.C[0].IsLessThan(c_old[0]);
            ctx.C[2] += 0x4D34D34D + ctx.C[1].IsLessThan(c_old[1]);
            ctx.C[3] += 0xD34D34D3 + ctx.C[2].IsLessThan(c_old[2]);
            ctx.C[4] += 0x4D34D34D + ctx.C[3].IsLessThan(c_old[3]);
            ctx.C[5] += 0xD34D34D3 + ctx.C[4].IsLessThan(c_old[4]);
            ctx.C[6] += 0x4D34D34D + ctx.C[5].IsLessThan(c_old[5]);
            ctx.C[7] += 0xD34D34D3 + ctx.C[6].IsLessThan(c_old[6]);
            ctx.Carry = ctx.C[7].IsLessThan(c_old[7]);

            // Se obtienen nuevos valores G.
            for (int i = 0; i < 8; i++)
                g[i] = FuncG(ctx.X[i] + ctx.C[i]);

            // Se crea el nuevo estado para X, usando los valores G que se obtuvieron previamente.
            ctx.X[0] = g[0] + Bitwise.ROTATE_LEFT(g[7], 16) + Bitwise.ROTATE_LEFT(g[6], 16);
            ctx.X[1] = g[1] + Bitwise.ROTATE_LEFT(g[0], 8) + g[7];
            ctx.X[2] = g[2] + Bitwise.ROTATE_LEFT(g[1], 16) + Bitwise.ROTATE_LEFT(g[0], 16);
            ctx.X[3] = g[3] + Bitwise.ROTATE_LEFT(g[2], 8) + g[1];
            ctx.X[4] = g[4] + Bitwise.ROTATE_LEFT(g[3], 16) + Bitwise.ROTATE_LEFT(g[2], 16);
            ctx.X[5] = g[5] + Bitwise.ROTATE_LEFT(g[4], 8) + g[3];
            ctx.X[6] = g[6] + Bitwise.ROTATE_LEFT(g[5], 16) + Bitwise.ROTATE_LEFT(g[4], 16);
            ctx.X[7] = g[7] + Bitwise.ROTATE_LEFT(g[6], 8) + g[5];
        }

        public UInt32 FuncG(UInt32 x)
        {
            UInt32 a = x & 0xFFFF;
            UInt32 b = x >> 16;
            UInt32 h = ((((a * a) >> 17) + (a + b)) >> 15) + b * b;
            UInt32 l = x * x;
            return h ^ l;
        }
    }
}
