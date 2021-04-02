
using System;

namespace Vojta
{
    public class Sorter
    {
        public void BubbleSort(int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
                for (var j = 0; j < numbers.Length - 1 - i; j++)
                    if (numbers[j] > numbers[j + 1])
                        (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
        }

        public void QuickSort(int[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length);
        }

        void QuickSort(int[] numbers, int start, int end)
        {
            if (start == end) return;
            var middle = Partition(numbers, start, end);
            QuickSort(numbers, start, middle);
            QuickSort(numbers, middle + 1, end);
        }



        int Partition(int[] numbers, int start, int end)
        {
            var pivot = numbers[start];
            var l = start + 1;
            var r = end - 1;
            while (true)
            {
                while (l <= r && numbers[l] < pivot)
                    l++;
                while (numbers[r] > pivot && r >= l)
                    r--;
                if (l > r)
                    break;
                else
                    Swap(numbers, l, r);
            }
            Swap(numbers, start, r);
            return r;
        }

        void Swap(int[] numbers, int l, int r)
        {
            var storage = numbers[r];
            numbers[r] = numbers[l];
            numbers[l] = storage;
        }
        public void MergeSort(int[] numbers)
        {
            var arr = MergeSort(numbers.AsSpan());
            Array.Copy(arr, numbers, arr.Length);
        }

        int[] MergeSort(Span<int> span)
        {
            if (span.Length == 1)
                return span.ToArray();

            var middle = span.Length / 2;
            var left = MergeSort(span.Slice(0, middle));
            var right = MergeSort(span.Slice(middle));
            return Merge(left, right);
        }

        int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];
            var l = 0;
            var r = 0;
            for (var i = 0; i < result.Length; i++)
            {
                if (l == left.Length)
                    result[i] = right[r++];
                else if (r == right.Length)
                    result[i] = left[l++];
                else if (left[l] <= right[r])
                    result[i] = left[l++];
                else
                    result[i] = right[r++];
            }
            return result;
        }
    }
}
