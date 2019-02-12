using System;

namespace ConsoleApp1
{

    class Player
    {
        int _min;
        int _max;
        int _lastGuess;

        public Player(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public int Guess()
        {
            _lastGuess = (_min + _max) / 2;
            return _lastGuess;
        }

        public void Bigger()
        {
            _min = _lastGuess;
        }

        public void Smaller()
        {
            _max = _lastGuess;
        }

    }


    class Program
    {
       
        int HumanGuess()
        {
            return int.Parse(Console.ReadLine());
        }

        static int PlayGame(int max)
        {
            var player = new Player(1, max);

            //Console.WriteLine("uhodni cislo mezi 1 az 1000 :D");
            var number = new Random().Next(1, max);
            int guess;
            int guessCount = 0;
            do
            {
                guess = player.Guess();
                guessCount++;
                //Console.WriteLine($"Guess: {guess}");
                if (number < guess)
                {
                    //Console.WriteLine("Mensi");
                    player.Smaller();
                }
                if (number > guess)
                {
                    //Console.WriteLine("Vetsi");
                    player.Bigger();
                }
            } while (guess != number);
            //Console.WriteLine("jupiiiiiii");
            return guessCount;
        }
        

        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                int length = PlayGame(32);
                Console.Write($"{length} ");
            }
        }
    }
}

