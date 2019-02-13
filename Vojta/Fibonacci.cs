using System.Reflection.Metadata.Ecma335;

namespace Vojta
{
    public class Fibonacci
    {
        //F(0)=0, F(1)=1, F(N)=F(N-1)+F(N-2)
        public int Fib(int n)
        {
            if(n==0)
                return 0;
            if (n == 1)
                return 1;
            return Fib(n-1)+Fib(n-2);
        }

        //[0, 1, 1, 2, 3, 5, 8
        public int[] FibArray(int n)
        {
            var result = new int[n];
            if (n > 1)
                result[1] = 1;
            for (var i = 2; i < n; i++)
                result[i] = result[i - 1] + result[i- 2];
            return result;
        }


    }
}