using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Algorithms.Rabbit.WinTest.Proceso
{
    internal class ProcesoPrincipal
    {
        #region - Singleton -
        public static ProcesoPrincipal Instancia = new ProcesoPrincipal();

        private ProcesoPrincipal()
        { }
        #endregion

        public byte[] Cipher(string textKey, string textIv, byte[] bytes)
        {
            var key = this.GetBytes(textKey, 16);
            var iv = this.GetBytes(textIv, 8);
            bytes = this.SquareBytes(bytes, 16);

            var rabbit = new RabbitAlgorithm(key);
            rabbit.IVSetup(iv);
            return rabbit.Cipher(bytes);
        }

        private byte[] GetBytes(string key, int length)
        {
            return this.SizeBytes(Encoding.Default.GetBytes(key), length);
        }

        private byte[] SquareBytes(byte[] bytes, int size)
        {
            var dif = bytes.Length % size;
            if (dif != 0)
                bytes = bytes.Concat(Enumerable.Repeat((byte)0x00, size - dif)).ToArray();
            return bytes;
        }

        private byte[] SizeBytes(byte[] bytes, int length)
        {
            if (bytes.Length > length)
            {
                byte[] buffer = new byte[length];
                Buffer.BlockCopy(bytes, 0, buffer, 0, length);
                bytes = buffer;
            }
            else if (bytes.Length < length)
            {
                var dif = length - bytes.Length;
                bytes = bytes.Concat(Enumerable.Repeat((byte)0x00, dif)).ToArray();
            }
            return bytes;
        }
    }
}
