using System;
using System.Collections.Generic;
using System.Text;

namespace Vojta
{
    public interface IFrequency
    {
        double GetFrequency(char ch);
    }

    public class EnglishFrequency : IFrequency
    {
        static IDictionary<char, double> f = new Dictionary<char, double>
        {
            ['e'] = 0.12,
            ['a'] = 0.08,
            ['i'] = 0.06,
            ['o'] = 0.07,
            ['u'] = 0.02,
            ['t'] = 0.09,
            ['n'] = 0.06,
            ['h'] = 0.06,
        };

        public double GetFrequency(char ch)
        {
            if (f.TryGetValue(ch, out double freq))
                return freq;
            return 0;
        }
    }


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

        public int FindKey(string message, IFrequency frequency)
        {
            int bestKey = -1;
            double bestScore = double.MaxValue;

            for (int key = 1; key < AlphabetSize; key++)
            {
                var text = Decode(message, key);
                var score = Evaluate(text, frequency);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestKey = key;
                }
            }
            return bestKey;
        }


        double Evaluate(string text, IFrequency frequecy)
        {
            var freq = new Dictionary<char, int>();
            foreach(var ch in text)
            {
                if (freq.ContainsKey(ch))
                    freq[ch]++;
                else
                    freq[ch] = 1;
            }
            var error = 0.0;
            foreach(var charFreq in freq)
            {
                var f = frequecy.GetFrequency(charFreq.Key);
                if (f == 0.0) continue;
                error += Math.Abs(f - (double)charFreq.Value / text.Length);
            }
            return error;
        }


        public string Decode(string cipher, int key)
        {
            var cipherLow = cipher.ToLower();
            return Encode(cipherLow, -key).ToLower();
        }

    }
}
