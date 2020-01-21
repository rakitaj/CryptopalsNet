using System;
using System.Collections.Generic;
using System.Text;

namespace CryptopalsNet.Core.Xor
{
    public class XorDecrypt
    {
        public ByteArray EncryptedText { get; private set; }

        public XorDecrypt(ByteArray encryptedText)
        {
            this.EncryptedText = encryptedText;
        }

        public ByteArray DecryptWithRepeatingKey(ByteArray decryptionKey)
        {
            var decryptedBytes = new List<byte>();
            for(int i = 0;  i < this.EncryptedText.Bytes.Count; i++)
            {
                var decryptionByteCounter = i % decryptionKey.Bytes.Count;
                var decryptedByte = this.EncryptedText.Bytes[i] ^ (decryptionKey.Bytes[decryptionByteCounter]);
                decryptedBytes.Add(Convert.ToByte(decryptedByte));
            }
            return new ByteArray(decryptedBytes);
        }
    }
}
