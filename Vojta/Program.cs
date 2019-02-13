using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Vojta
{
    class Program
    {



        static void Main(string[] args)
        {
            var numbers = new[] { -1000, -10, -2, 100, -111 };
            var numbers2 = new[] {11, 22, 33};
            //var numbers = new int[0];
            //Console.WriteLine($"Biggest number of array is {Biggest(numbers)}");
            //var biggest = Biggest(numbers);
            //Console.WriteLine("Biggest " + biggest);
            //Console.WriteLine(Contains(numbers, -100));
            //Console.WriteLine(Contains(numbers, 100));
            //Console.WriteLine(string.Join(", ", Odd(numbers)));
            Console.WriteLine(string.Join(", ", Concat(numbers, numbers2)));
        }

        static int[] Concat(int[] numbers, int[] numbers2)
        {
            var result = new int[numbers.Length+numbers2.Length];
            Array.Copy(numbers,result,numbers.Length);
            Array.Copy(numbers2,0,result,numbers.Length,numbers2.Length);
            return result;
        }

        static int[] Odd(int[] numbers)
        {
            var count = numbers.Length / 2 + numbers.Length % 2;
            
            var odds = new int[count];
            for (var i = 0; i < odds.Length; i++)
                odds[i] = numbers[i*2];
            return odds;
        }

        //static IEnumerable<int> Odd(int[] numbers)
        //{
        //    for (var i = 0; i < numbers.Length; i += 2)
        //        yield return numbers[i];
        //}

        static bool Contains(int[] numbers, int number)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                    return true;
               
            }
            return false;
        }

        static int Biggest(int[] numbers)
        {
            var biggest = int.MinValue;
            for (var i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > biggest)
                    biggest = numbers [i];
            }

            return biggest;

        }  
            
        
    
    
    }
}
