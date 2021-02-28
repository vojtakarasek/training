using System.IO;

namespace Vojta
{
    public class GcdCalculator
    {
        public int Gcd(int x, int y)
        {
            ValidateInput(x);
            ValidateInput(y);
            if (x == 0)
            {
                return y;
            }
            if (y == 0)
            {
                return x;
            }
            while (x != y)
            {
                if (x > y)
                    x -= y;
                else
                    y -= x;
            }
            return x;
        }

        void ValidateInput(int x)
        {
            if (x < 0)
                throw new InvalidDataException();
        }

        public int GcdFaster(int x, int y)
        {
            ValidateInput(x);
            ValidateInput(y);
            var a = x;
            var b = y;
            while (true)
            {
                if (a < b)
                   (a, b) = (b, a);
                if (b == 0)
                    return a;
                a %= b;
            }
        }
        public int Gcd(int x, int y, int z)
        {
            return Gcd(GcdFaster(x, y), z);
        }
    }
}
