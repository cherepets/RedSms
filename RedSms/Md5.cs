using System.Security.Cryptography;
using System.Text;

namespace RedSms
{
    internal class Md5
    {
        private byte[] _hash;

        public Md5(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            _hash = md5.ComputeHash(inputBytes);
        }

        public byte[] GetBytes() => _hash;

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var b in _hash)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}
