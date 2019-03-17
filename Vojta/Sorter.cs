using System;
using System.Collections.Generic;
using System.Text;

namespace Vojta
{
    public class Sorter
    {
        public void BubbleSort(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
                for (var j = 0; j < numbers.Length - 1; j++)
                    if (numbers[j] > numbers[j + 1])
                    {
                        var storage = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = storage;
                    }
        }
    }
}
