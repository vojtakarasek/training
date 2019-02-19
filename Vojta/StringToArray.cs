using System;
using System.Collections.Generic;

namespace Vojta
{

    public class StringToArray
    {
        //Write a function that takes a number and returns a list of its digits. So for 2342 it should return [2,3,4,2].
        public IEnumerable<int> ConvertDigits(string expression)
        {
            var result = new int[expression.Length];
            for (int i = 0; i < expression.Length; i++)
            {
                result[i] = expression[i] - '0';
            }
            return result;
        }

        public IEnumerable<int> Convert(string expression)
        {
            var numbers = expression.Split(',', StringSplitOptions.RemoveEmptyEntries); //"1,3,24" -> ["1", "3", "24"]

            //["1", "2", "24"] -> [1, 2, 24]

            var result = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = int.Parse(numbers[i]);
            }
            return result;
        }

    }
}