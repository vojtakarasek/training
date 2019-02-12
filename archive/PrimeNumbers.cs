{
    class Program
    {
       static bool IsPrime(int number)
        {
            for (var i = 2; i < number; i++)
                if (number % i == 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            int count = 0;
            for (var i = 1; i <= 1000000; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + " ");
                    count++;
                }
            }
            Console.WriteLine($"Pocet prvocislel mensich nez milion je {count}");
        }
    }
}