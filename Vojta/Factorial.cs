namespace Vojta
{
    public class FactorialCalc
    {
        //F(0)=1, F(1)=1, F(N)=F(N) * F(N-1) * .. 1
        public int Factorial(int n)
        {
            if (n==0)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}