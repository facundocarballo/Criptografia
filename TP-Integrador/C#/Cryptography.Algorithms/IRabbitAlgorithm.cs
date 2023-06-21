namespace Cryptography.Algorithms
{
    public interface IRabbitAlgorithm
    {
        byte[] Cipher(byte[] data);
        void IVSetup(byte[] iv);
    }
}