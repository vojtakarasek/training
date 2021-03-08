using System.Linq;

namespace Vojta
{
    public class FactorialCalc
    {
        //F(0)=1, F(1)=1, F(N)= N * F(N-1)
        public int Factorial(int n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }

        public int FactorialCycle(int n)
        {
            var result = 1;
            while (n > 0)
            {
                result = n * result;
                n--;
            }
            return result;
        }

        public int FactorialRange(int n) => Enumerable.Range(1, n).Aggregate(1, (acc, i) => acc * i);

        public int FactorialFor(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}