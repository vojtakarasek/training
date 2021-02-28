namespace Vojta
{
    public class GcdCalculator
    {
        public int Gcd(int x, int y)
        {
            while (x != y)
            {
                if (x > y)
                    x -= y;
                else
                    y -= x;
            }
            return x;
        }

        public int GcdFaster(int x, int y)
        {
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
    }
}
