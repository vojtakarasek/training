using System;
using System.Collections.Generic;
using System.Text;

namespace Vojta
{
    public class Caesar
    {
        const int AlphabetSize = 'z' - 'a' + 1;

        public string PrepareData(string input)
        {
            var sb = new StringBuilder();
            foreach (var ch in input)
            {
                if (ch >= 'a' && ch <= 'z')
                    sb.Append(ch);
                else if (ch >= 'A' && ch <= 'Z')
                    sb.Append(char.ToLower(ch));
            }
            return sb.ToString();
        }

        public string Encode(string plain, int key )
        {
            var sb = new StringBuilder();
            foreach(var ch in plain)
            {
                var ascii = ch + key;
                if (ascii > 'z')
                    ascii -= AlphabetSize;
                if (ascii < 'a')
                    ascii += AlphabetSize;
                var c = char.ToUpper((char)ascii);
                sb.Append(c);
            }
            return sb.ToString();
        }

        public string Decode(string cipher, int key)
        {
            var cipherLow = cipher.ToLower();
            return Encode(cipherLow, -key).ToLower();
        }

    }
}
